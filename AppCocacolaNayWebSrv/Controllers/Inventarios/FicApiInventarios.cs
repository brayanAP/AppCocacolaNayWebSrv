using AppCocacolaNayWebSrv.Models;
using AppCocacolaNayWebSrv.Models.Inventarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppCocacolaNayWebSrv.Controllers
{
    [Produces("application/json")]
    public class FicApiInventarios : Controller
    {
        private readonly FicDBContext FicLoDBContext;

        public FicApiInventarios(FicDBContext FicPaDBContext)
        {
           FicLoDBContext = FicPaDBContext;
           
        }//constructor

        [HttpGet]
        [Route("api/inventarios/invacocon")]
        public async Task<IActionResult> FicApiGetListInventarios()
        {
            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios select data_inv).ToList();

            if (zt_inventarios != null)
            {
                var zt_inventarios_acumulados = (from data_acu in FicLoDBContext.zt_inventarios_acumulados select data_acu).ToList();

                var zt_inventarios_conteos = (from data_con in FicLoDBContext.zt_inventarios_conteos select data_con).ToList();

                zt_inventatios_acumulados_conteos temp = new zt_inventatios_acumulados_conteos();
                temp.zt_inventarios = zt_inventarios.ToList();

                if (zt_inventarios_acumulados != null)
                {
                    temp.zt_inventarios_acumulados = zt_inventarios_acumulados.ToList();
                }

                if (zt_inventarios_conteos != null)
                {
                    temp.zt_inventarios_conteos = zt_inventarios_conteos.ToList();
                }

                return Ok(temp);
            }

            return NotFound("SIN INVENTARIOS");
        }//http://localhost:60304/api/inventarios/invacocon

        [HttpGet]
        [Route("api/inventarios/invacoconid")]
        public async Task<IActionResult> FicApiGetListInventarioss([FromQuery]int id)
        {
            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios where data_inv.IdInventario == id select data_inv).ToList();

            if (zt_inventarios != null)
            {
                var zt_inventarios_acumulados = (from data_acu in FicLoDBContext.zt_inventarios_acumulados select data_acu).ToList();

                var zt_inventarios_conteos = (from data_con in FicLoDBContext.zt_inventarios_conteos select data_con).ToList();

                zt_inventatios_acumulados_conteos temp = new zt_inventatios_acumulados_conteos();
                temp.zt_inventarios = zt_inventarios.ToList();

                if (zt_inventarios_acumulados != null)
                {
                    temp.zt_inventarios_acumulados = zt_inventarios_acumulados.ToList();
                }

                if (zt_inventarios_conteos != null)
                {
                    temp.zt_inventarios_conteos = zt_inventarios_conteos.ToList();
                }

                return Ok(temp);
            }

            return NotFound("SIN INVENTARIOS");
        }//http://localhost:60304/api/inventarios/invacocon?id=4001

        [HttpGet]
        [Route("api/inventarios/catalogos")]
        public async Task<IActionResult> FicApiGetListCatalogos()
        {
                return Ok(new zt_catalogos_productos_medidas_cedi_almacenes() {
                    zt_cat_productos = await (from pro in FicLoDBContext.zt_cat_productos select pro).ToListAsync(),
                    zt_cat_unidad_medidas = await (from med in FicLoDBContext.zt_cat_unidad_medidas select med).ToListAsync(),
                    zt_cat_productos_medidas = await (from prm in FicLoDBContext.zt_cat_productos_medidas select prm).ToListAsync(),
                    zt_cat_cedis = await (from ced in FicLoDBContext.zt_cat_cedis select ced).ToListAsync(),
                    zt_cat_almacenes = await (from alm in FicLoDBContext.zt_cat_almacenes select alm).ToListAsync()
                });
        }//http://localhost:60304/api/inventarios/catalogos

        private async Task<zt_inventarios> FicExistzt_inventarios(int id)
        {
            return await (from inv in FicLoDBContext.zt_inventarios where inv.IdInventario == id select inv).SingleOrDefaultAsync();
        }//buscar en local

        private async Task<zt_inventarios_conteos> FicExistzt_inventarios_conteos(int idinv, int IdAlmacen, string codigob, int NumCont, string ubicacion)
        {
            return await (from con in FicLoDBContext.zt_inventarios_conteos where con.IdInventario == idinv && con.IdAlmacen == IdAlmacen && con.IdSKU == codigob && con.NumConteo == NumCont && con.IdUbicacion == ubicacion select con).SingleOrDefaultAsync();
        }//buscar en local

        private async Task<zt_inventarios_acumulados> FicExistzt_inventarios_acumulados(int idinv, string idsku)
        {
            return await (from acu in FicLoDBContext.zt_inventarios_acumulados where acu.IdInventario == idinv && acu.IdSKU == idsku select acu).SingleOrDefaultAsync();
        }//buscar en local


        [HttpPost]
        [Route("api/inventarios/invacocon/export")]
        public async Task<IActionResult> FicGetImportInventarios([FromBody] zt_inventatios_acumulados_conteos FicGetListInventarioActualiza)
        {
            string FicMensaje = "";
            try
            {
                FicMensaje = "IMPORTACION: \n";
                

                if (FicGetListInventarioActualiza.zt_inventarios != null)
                {
                    FicMensaje += "IMPORTANDO: zt_inventarios \n";
                    foreach (zt_inventarios inv in FicGetListInventarioActualiza.zt_inventarios)
                    {
                        var respuesta = await FicExistzt_inventarios(inv.IdInventario);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdInventario = inv.IdInventario;
                                respuesta.IdCEDI = inv.IdCEDI;
                                respuesta.FechaReg = inv.FechaReg;
                                respuesta.UsuarioReg = inv.UsuarioReg;
                                respuesta.FechaUltMod = inv.FechaUltMod;
                                respuesta.UsuarioMod = inv.UsuarioMod;
                                respuesta.Activo = inv.Activo;
                                respuesta.Borrado = inv.Borrado;
                                // FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoDBContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdInventario: " + inv.IdInventario + " \n" : "-NO NECESITO ACTUALIZAR->  IdInventario: " + inv.IdInventario + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoDBContext.Add(inv);
                                FicMensaje += await FicLoDBContext.SaveChangesAsync() > 0 ? "-INSERT-> IdInventario: " + inv.IdInventario + " \n" : "-ERROR EN INSERT-> IdInventario: " + inv.IdInventario + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";

                if (FicGetListInventarioActualiza.zt_inventarios_conteos != null)
                {
                    FicMensaje += "IMPORTANDO: zt_inventarios_conteos \n";
                    foreach (zt_inventarios_conteos inv in FicGetListInventarioActualiza.zt_inventarios_conteos)
                    {
                        var respuesta = await FicExistzt_inventarios_conteos(inv.IdInventario, inv.IdAlmacen, inv.IdSKU, inv.NumConteo, inv.IdUbicacion);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdInventario = inv.IdInventario;
                                respuesta.IdAlmacen = inv.IdAlmacen;
                                respuesta.NumConteo = inv.NumConteo;
                                respuesta.IdSKU = inv.IdSKU;
                                respuesta.CodigoBarras = inv.CodigoBarras;
                                respuesta.IdUbicacion = inv.IdUbicacion;
                                respuesta.CantidadFisica = inv.CantidadFisica;
                                respuesta.IdUnidadMedida = inv.IdUnidadMedida;
                                respuesta.CantidadPZA = inv.CantidadPZA;
                                respuesta.Lote = inv.Lote;
                                respuesta.FechaReg = inv.FechaReg;
                                respuesta.UsuarioReg = inv.UsuarioReg;
                                respuesta.Activo = inv.Activo;
                                respuesta.Borrado = inv.Borrado;
                                //FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoDBContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdInventario: " + inv.IdInventario + " ,IdAlmacen: " + inv.IdAlmacen + " ,IdSKU: " + inv.IdSKU + " ,NumConteo: " + inv.NumConteo + " ,IdUbicacion: " + inv.IdUbicacion + " \n" : "-NO NECESITO ACTUALIZAR-> IdInventario: " + inv.IdInventario + " ,IdAlmacen: " + inv.IdAlmacen + " ,IdSKU: " + inv.IdSKU + " ,NumConteo: " + inv.NumConteo + " ,IdUbicacion: " + inv.IdUbicacion + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoDBContext.Add(inv);
                                FicMensaje += await FicLoDBContext.SaveChangesAsync() > 0 ? "-INSERT-> IdInventario: " + inv.IdInventario + " ,IdAlmacen: " + inv.IdAlmacen + " ,IdSKU: " + inv.IdSKU + " ,NumConteo: " + inv.NumConteo + " ,IdUbicacion: " + inv.IdUbicacion + " \n" : "-ERROR EN INSERT-> IdInventario: " + inv.IdInventario + " ,IdAlmacen: " + inv.IdAlmacen + " ,IdSKU: " + inv.IdSKU + " ,NumConteo: " + inv.NumConteo + " ,IdUbicacion: " + inv.IdUbicacion + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";

                if (FicGetListInventarioActualiza.zt_inventarios_acumulados != null)
                {
                    FicMensaje += "IMPORTANDO: zt_inventarios_acumulados \n";
                    foreach (zt_inventarios_acumulados inv in FicGetListInventarioActualiza.zt_inventarios_acumulados)
                    {
                        var respuesta = await FicExistzt_inventarios_acumulados(inv.IdInventario, inv.IdSKU);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdInventario = inv.IdInventario;
                                respuesta.IdSKU = inv.IdSKU;
                                respuesta.CantidadTeorica = inv.CantidadTeorica;
                                respuesta.CantidadFisica = inv.CantidadFisica;
                                respuesta.Diferencia = inv.Diferencia;
                                respuesta.IdUnidadMedida = inv.IdUnidadMedida;
                                respuesta.FechaReg = inv.FechaReg;
                                respuesta.UsuarioReg = inv.UsuarioReg;
                                respuesta.FechaUltMod = inv.FechaUltMod;
                                respuesta.UsuarioMod = inv.UsuarioMod;
                                respuesta.Activo = inv.Activo;
                                respuesta.Borrado = inv.Borrado;
                                //FicLoBDContext.Update(respuesta);
                                FicMensaje += await FicLoDBContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdInventario: " + inv.IdInventario + " ,IdSKU: " + inv.IdSKU + " \n" : "-NO NECESITO ACTUALIZAR-> IdInventario: " + inv.IdInventario + " ,IdSKU: " + inv.IdSKU + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoDBContext.Add(inv);
                                FicMensaje += await FicLoDBContext.SaveChangesAsync() > 0 ? "-INSERT-> IdInventario: " + inv.IdInventario + " ,IdSKU: " + inv.IdSKU + " \n" : "-ERROR EN INSERT-> IdInventario: " + inv.IdInventario + " ,IdSKU: " + inv.IdSKU + " \n";
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else FicMensaje += "-> SIN DATOS. \n";
            }
            catch (Exception e)
            {
                FicMensaje += "ALERTA: " + e.Message.ToString() + "\n";
            }
            return Ok(FicMensaje);
        }//http://localhost:60304/api/inventarios/invacocon/export


    }//class
}
