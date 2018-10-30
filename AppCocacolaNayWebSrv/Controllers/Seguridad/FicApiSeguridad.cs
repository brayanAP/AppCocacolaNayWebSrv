using AppCocacolaNayWebSrv.Models;
using AppCocacolaNayWebSrv.Models.Inventarios;
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

        //[HttpGet]
        //[Route("api/seguridad/paginacion")]
        //public async Task<IActionResult> FicApiGetListPaginacion()
        //{
        //    var FicSourcePaginas = new seg_cat_mod_sub_pag()
        //    {
        //        seg_cat_modulos = await (from mod in FicLoDBContext.seg_cat_modulos select mod).ToListAsync(),
        //        seg_cat_submodulos = await (from mod in FicLoDBContext.seg_cat_submodulos select mod).ToListAsync(),
        //        seg_cat_paginas = await (from pag in FicLoDBContext.seg_cat_paginas select pag).ToListAsync()
        //    };

        //    if (FicSourcePaginas.seg_cat_modulos.Count != 0 && FicSourcePaginas.seg_cat_submodulos.Count != 0 && FicSourcePaginas.seg_cat_paginas.Count != 0)
        //        return Ok(FicSourcePaginas);
        //    else return NotFound("SIN PAGINAS");

        //}//http://localhost:54068/api/seguridad/paginacion



        //[HttpGet]
        //[Route("api/seguridad/login")]
        //public async Task<IActionResult> FicApiGetLogin([FromQuery] string user, [FromQuery] string password)
        //{
        //    //try
        //    //{
        //        var FicSourceUser = await (
        //            from u in FicLoDBContext.cat_usuarios
        //            from p in FicLoDBContext.rh_cat_personas
        //            join c in FicLoDBContext.seg_expira_claves on u.IdUsuario equals c.IdUsuario
        //            join e in FicLoDBContext.seg_usuarios_estatus on u.IdUsuario equals e.IdUsuario
        //            where (u.Usuario == user && u.Expira == "N" && u.Activo == "S") &&
        //                  (c.Actual == "S" && /*((DateTime.Now.Date >= c.FechaExpiraIni.Value.Date) && (DateTime.Now.Date <= c.FechaExpiraFin.Value.Date))*///) &&
        //                  /*(*/e.IdTipoEstatus == 4001 && e.IdEstatus == 5001) && (p.IdPersona == u.IdPersona)
        //            select new { u,p, c, e }).GroupBy(v => v.u).Select(group => new
        //            {
        //                cat_usuarios = group.First().u,
        //                rh_cat_personas = group.First().p,
        //                seg_usuarios_estatus = group.First().e,
        //                seg_expira_claves = group.First().c
        //            }).SingleOrDefaultAsync();

        //        if (FicSourceUser != null /*|| (FicSourceUser.u != null || FicSourceUser.c != null || FicSourceUser.e != null)*/)
        //            return Ok(new temp_web_api_login()
        //            {
        //                cat_usuarios = FicSourceUser.cat_usuarios,
        //                seg_expira_claves = FicSourceUser.seg_expira_claves,
        //                seg_usuarios_estatus = FicSourceUser.seg_usuarios_estatus,
        //                rh_cat_personas = FicSourceUser.rh_cat_personas
        //            });
        //        else
        //            return NotFound("USUARIO INVALIDO");
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    return NotFound(e.Message.ToString());
        //    //}

        //}//http://localhost:54068/api/seguridad/login?user=BUAP&password=cosa

        //cat_usuarios->seg_roles_usuarios->seg_cat_roles->seg_roles_paginas

    }//class
}
