using AppCocacolaNayWebSrv.Models;
using AppCocacolaNayWebSrv.Models.Seguridad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCocacolaNayWebSrv.Controllers
{
    [Produces("application/json")]
    public class FicApiSeguridad : Controller
    {
        /*PARA MANEJAR LA CONEXION ENTRE EL MODELO Y EL SQLSERVER*/
        private readonly FicDBContext FicLoDBContext;

        public FicApiSeguridad(FicDBContext FicPaDBContext)
        {
           FicLoDBContext = FicPaDBContext;
        }//constructor

        private string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#%^&*()_,./<>?;:[]{}|=+";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }//GENERAR UNA CONTRASEÑA TEMPORAL

        private async Task<bool> FicUpdateCreateReiniciaClave(seg_usuarios_estatus item1, seg_usuarios_estatus item2, seg_expira_claves item3)
        {
            using (var context = new FicDBContext())
            {

                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        /*ACTUALIZA EN seg_usuarios_estatus*/
                        FicLoDBContext.seg_usuarios_estatus.Update(item1);
                        await FicLoDBContext.SaveChangesAsync();

                        /*CREA EN seg_usuarios_estatus*/
                        await FicLoDBContext.seg_usuarios_estatus.AddAsync(item2);
                        await FicLoDBContext.SaveChangesAsync();

                        /*CREAR EN seg_expira_claves*/
                        await FicLoDBContext.seg_expira_claves.AddAsync(item3);
                        await FicLoDBContext.SaveChangesAsync();


                        transaction.Commit(); //CONFIRMA/GUARDA
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }//ENTRA EN CONTEXTO DE TRANSACIONES
            }//ATRAVEZ DEL CONTEXTO DE LA BD
        }//FicUpdateCreateReiniciaClave

        private async Task<bool> FicUpdateCreateCambiaClave(seg_expira_claves item1, seg_expira_claves item2)
        {
            using (var context = new FicDBContext())
            {

                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        /*ACTUALIZA EN seg_expira_claves*/
                        FicLoDBContext.seg_expira_claves.Update(item1);
                        await FicLoDBContext.SaveChangesAsync();

                        /*CREAR EN seg_expira_claves*/
                        await FicLoDBContext.seg_expira_claves.AddAsync(item2);
                        await FicLoDBContext.SaveChangesAsync();


                        transaction.Commit(); //CONFIRMA/GUARDA
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }//ENTRA EN CONTEXTO DE TRANSACIONES
            }//ATRAVEZ DEL CONTEXTO DE LA BD
        }//FicUpdateCreateReiniciaClave

        [HttpGet]
        [Route("api/seguridad/reiniciaclave")]
        public async Task<IActionResult> FicApiGetItemReiniciaClave([FromQuery] string user, [FromQuery] string correo)
        {
            var var_cat_usuarios = await (
                                         from usuario in FicLoDBContext.cat_usuarios
                                         join estatus in FicLoDBContext.seg_usuarios_estatus on usuario.IdUsuario equals estatus.IdUsuario
                                         join persona in FicLoDBContext.rh_cat_personas on usuario.IdPersona equals persona.IdPersona
                                         join web in FicLoDBContext.rh_cat_dir_web on persona.IdPersona equals Int32.Parse(web.ClaveReferencia)
                                         where usuario.Usuario == user && (web.DirWeb == correo && web.Principal == "S" && web.Referencia == "rh_cat_personas") && (web.IdGenDirWeb == 2 && web.IdTipoGenDirWeb == 2) && (estatus.Actual == "S" && estatus.IdTipoEstatus == 1 && estatus.IdEstatus == 1)
                                         select new
                                         {
                                             usuario,
                                             web,
                                             estatus
                                         }
                                        ).SingleOrDefaultAsync();

            if (var_cat_usuarios == null)
            {
                return NotFound("USUARIO NO ENCONTRADO.");
            }//USUARIO NO ENCONTRADO

            /*ACTUALIZA EN cat_usuarios*/
            var updateUsuario = var_cat_usuarios.estatus;
            updateUsuario.Actual = "N";

            /*CREA EN seg_usuarios_estatus */
            var createEstatus = new seg_usuarios_estatus()
            {
                IdUsuario = var_cat_usuarios.usuario.IdUsuario,
                FechaEstatus = DateTime.Now,
                IdTipoEstatus = 1,
                IdEstatus = 5,
                Actual = "N",
                UsuarioReg = "ADMINWEBAPI",
                FechaReg = DateTime.Now,
                Activo = "S",
                Borrado = "N"
            };


            /*CREAR EN seg_expira_claves*/
            var createClave = new seg_expira_claves()
            {
                IdUsuario = var_cat_usuarios.usuario.IdUsuario,
                FechaExpiraIni = DateTime.Now,
                FechaExpiraFin = DateTime.Now, /*en el mismo dia pero que pero al final del dia*/
                Actual = "N",
                Clave = this.CrearPassword(8),
                ClaveAutoSys = "S",
                FechaReg = DateTime.Now,
                UsuarioReg = "ADMINWEBAPI",
                Activo = "N",
                Borrado = "N"
            };

            var respuesta = await FicUpdateCreateReiniciaClave(updateUsuario, createEstatus, createClave);

            if (!respuesta)
            {
                return NotFound("OCURRIO UN PROBLEMA.");
            }

            return Ok(createClave.Clave);
        }//http://localhost:60304/api/seguridad/reiniciaclave?user=FIBARRAC&correo=fibarra@ittepic.edu.mx

        [HttpGet]
        [Route("api/seguridad/actualizaclave")]
        public async Task<IActionResult> FicApiPutItemActualizaClave([FromQuery] string user, [FromQuery] string password, [FromQuery] string newpassword, [FromQuery] string confirmpassword)
        {
            var var_cat_usuarios = await (
                                         from usuario in FicLoDBContext.cat_usuarios
                                         join estatus in FicLoDBContext.seg_usuarios_estatus on usuario.IdUsuario equals estatus.IdUsuario
                                         join clave in FicLoDBContext.seg_expira_claves on usuario.IdUsuario equals clave.IdUsuario
                                         where usuario.Usuario == user && (estatus.Actual == "S" && estatus.IdTipoEstatus == 1 && estatus.IdEstatus == 1) && (clave.Actual == "S" && clave.Clave == password)
                                         select new
                                         {
                                             usuario,
                                             clave,
                                             estatus
                                         }
                                        ).SingleOrDefaultAsync();

            if (var_cat_usuarios == null)
            {
                return NotFound("Usuario no disponible para actualizacion.");
            }//USUARIO NO ENCONTRADO

            if (newpassword != confirmpassword)
            {
                return NotFound("Las Claves No Coinciden.");
            }//Las Claves No Coinciden

            if (newpassword == password)
            {
                return NotFound("La Clave no puede ser igual a la anterior.");
            }//La Clave no puede ser igual a la anterior

            //Pongo la contraseña vieja en actual N
            var updateClave = var_cat_usuarios.clave;
            updateClave.Actual = "N";

            var createClave = new seg_expira_claves()
            {
                IdUsuario = var_cat_usuarios.usuario.IdUsuario,
                FechaExpiraIni = DateTime.Now,
                FechaExpiraFin = (DateTime.Now).AddMonths(6), /* Fecha dentro de 6 meses*/
                Actual = "S",
                Clave = newpassword,
                ClaveAutoSys = "N",
                FechaReg = DateTime.Now,
                UsuarioReg = "ADMINWEBAPI",
                Activo = "S",
                Borrado = "N"
            };

            var respuesta = await FicUpdateCreateCambiaClave(updateClave, createClave);

            if (!respuesta)
            {
                return NotFound("CLAVE NO REGISTRADA.");
            }

            return Ok("Clave actualizada con exito");
        }//http://localhost:60304/api/seguridad/actualizaclave?user=FIBARRAC&password=ddjhch&newpassword=12345&confirmpassword=12345


        [HttpGet]
        [Route("api/seguridad/login")]
        public async Task<IActionResult> FicApiGetItemVerificaUsuario([FromQuery] string user, [FromQuery] string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await ((
                           /*HACEMOS LA BUSQUEDA*/
                           from usuario in FicLoDBContext.cat_usuarios
                           join status in FicLoDBContext.seg_usuarios_estatus on usuario.IdUsuario equals status.IdUsuario
                           join clave in FicLoDBContext.seg_expira_claves on usuario.IdUsuario equals clave.IdUsuario
                           join persona in FicLoDBContext.rh_cat_personas on usuario.IdPersona equals persona.IdPersona
                           join telefonos in FicLoDBContext.rh_cat_telefonos on persona.IdPersona equals Int32.Parse(telefonos.ClaveReferencia)
                           join general in FicLoDBContext.cat_generales on telefonos.IdGenTelefono equals general.IdGeneral
                           join web in FicLoDBContext.rh_cat_dir_web on persona.IdPersona equals Int32.Parse(web.ClaveReferencia)
                           where (usuario.Usuario == user) && (clave.Actual == "S") && (status.Actual == "S") && (telefonos.Principal == "S" && telefonos.Referencia == "rh_cat_personas") && (web.Principal == "S" && web.Referencia == "rh_cat_personas")
                           select new
                           {
                               usuario,
                               status,
                               clave,
                               persona,
                               telefonos,
                               general,
                               web
                           }
                           /*AGRUPAMOS EL RESULTADO*/
                           ).GroupBy(v => v.usuario.IdUsuario).Select(group => new
                           {
                               cat_usuarios = group.First().usuario,
                               rh_cat_personas = group.First().persona,
                               seg_usuarios_estatus = group.First().status,
                               seg_expira_claves = group.First().clave,
                               cat_generales = group.First().general,
                               rh_cat_dir_web = group.First().web,
                               list_telefonos = group.Select(v => new { rh_cat_telefonos = v.telefonos })
                           })
                        /*LO CONVERTIMOS A UN SOLO RESULTADO*/
                        ).SingleOrDefaultAsync();

            var param = await (
                          /*HACEMOS LA BUSQUEDA*/
                          from parametro in FicLoDBContext.cat_parametros
                          where (parametro.IdParametro == 1)
                          select new
                          {
                              parametro
                          }).SingleOrDefaultAsync();

            if (result == null)
            {
                return NotFound("Usuario Incorrecto.");
            }//VALIDAR NO ENCONTRADO O FUERA DE ESTATUS

            if (result.seg_expira_claves.Clave != password)
            {
                if (result.cat_usuarios.NumIntentos == Int32.Parse(param.parametro.Valor))
                {
                    //Cambiar el estado a bloqueado por intentos//////////////////////////////////
                    //var tempEstatus = result.seg_usuarios_estatus;
                    //tempEstatus.Actual = "N";
                    //if (!(UpdateEstatusUsuario(tempEstatus)))
                    //{
                    //    return NotFound("ESTATUS NO MODIFICADO.");
                    //}//NO SE PUEDO ACTUALIZAR EL ESTATUS DEL USUARIO

                    //bool estado = await CreateEstatusUsuario(new seg_usuarios_estatus()
                    //{
                    //    IdUsuario = result.cat_usuarios.IdUsuario,
                    //    FechaEstatus = DateTime.Now,
                    //    IdTipoEstatus = 1,
                    //    IdEstatus = 4,
                    //    Actual = "S",
                    //    UsuarioReg = "ADMINWEBAPI",
                    //    FechaReg = DateTime.Now,
                    //    Activo = "S",
                    //    Borrado = "N"
                    //});

                    //if (!estado)
                    //{
                    //    return NotFound("ESTATUS NO CREADO.");
                    //}//NO SE PUEDE CREAR EL ESTATUS DEL USUARIO

                    return NotFound("Intentos Maximos alcanzados, usuario bloqueado.");
                }//Intentos Maximos alcanzados

                //// Modificar los intentos maximos
                //var tempUsuario = result.cat_usuarios;
                //tempUsuario.NumIntentos = tempUsuario.NumIntentos++;
                //if (!(UpdateUsuario(tempUsuario)))
                //{
                //    return NotFound("Intentos no incrementados.");
                //}//Intentos aumentados

                return NotFound("Contraseña Incorrecta.");
            }//Contraseña Incorrecta

            if (!((DateTime.Now.Date >= result.seg_expira_claves.FechaExpiraIni.Value.Date) && (DateTime.Now.Date <= result.seg_expira_claves.FechaExpiraFin.Value.Date)))
            {
                //ventana modal para cambiar contraseña/////////////////////

                return NotFound("Contraseña Expirada.");
            }//VALIDAR EXPIRACION DE LA CLAVE


            if (result.seg_expira_claves.ClaveAutoSys == "S")
            {
                //ventana modal para cambiar contraseña/////////////////

                return NotFound("Clave Generada Por Sistema.");
            }//Clave auto sys

            if (result.seg_usuarios_estatus.IdEstatus == 4)
            {
                return NotFound("Usuario Bloqueado Por Intentos.");
            }//Estatus bloqueado(intentos)

            if (result.seg_usuarios_estatus.IdEstatus == 3)
            {
                return NotFound("Usuario Bloqueado.");
            }//Estatus bloqueado(temporal)

            if (result.seg_usuarios_estatus.IdEstatus == 2)
            {
                return NotFound("Usuario Inactivo.");
            }//Estatus inactivo

            if (result.seg_usuarios_estatus.IdEstatus == 5)
            {
                //verificar si entra con la contraseña vieja o con la nueva////////////////////////////////

                return NotFound("Usuario Reinicia Contraseña.");
            }//Estatus recuperacion

            return Ok(result);
        }//http://localhost:60304/api/seguridad/login?user=BARIASP&password=Brayan01


    }//class
}
