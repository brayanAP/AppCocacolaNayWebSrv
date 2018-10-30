using AppCocacolaNayWebSrv.Models.Eva;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCocacolaNayWebSrv.Models.Seguridad
{
    public class cat_usuarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }//PK
        public int IdPersona { get; set; }//FK
        public rh_cat_personas rh_cat_personas { get; set; }
        [StringLength(20)]
        public string Usuario { get; set; }
        [StringLength(1)]
        public string Expira { get; set; }
        [StringLength(1)]
        public string Conectado { get; set; }
        public Nullable<DateTime> FechaAlta { get; set; }
        public Nullable<Int16> NumIntentos { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }


    }//ok

    public class seg_usuarios_estatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCrtlEstatus { get; set; }//PK
        public int IdUsuario { get; set; }//FK
        public Nullable<DateTime> FechaEstatus { get; set; }
        public Nullable<Int16> IdTipoEstatus { get; set; }//FK
        public cat_tipos_estatus cat_tipos_estatus { get; set; }
        public Nullable<Int16> IdEstatus { get; set; }//FK
        public cat_estatus cat_estatus { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        [StringLength(500)]
        public string Observacion { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//OK

    public class seg_expira_claves
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdClave { get; set; }//PK
        public int IdUsuario { get; set; }//PK FK
        public cat_usuarios cat_usuarios { get; set; }
        public Nullable<DateTime> FechaExpiraIni { get; set; }
        public Nullable<DateTime> FechaExpiraFin { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        [StringLength(20)]
        public string Clave { get; set; }
        [StringLength(1)]
        public string ClaveAutoSys { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//OK

    public class seg_cat_roles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRol { get; set; }//PK
        [StringLength(200)]
        public string DesRol { get; set; }
        public Nullable<int> DefaultDiasActivo { get; set; }
        public Nullable<Int16> IdTipoGenRol { get; set; }//FK
        public cat_tipos_generales cat_tipos_generales { get; set; }
        public Nullable<Int16> IdGenRol { get; set; }//FK
        public cat_generales cat_generales { get; set; }
        [StringLength(1000)]
        public string Observacion { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<Int16> FechaReg { get; set; }
        public string UsuarioMod { get; set; }
        public Nullable<Int16> FechaUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }//ok

    public class seg_roles_usuarios
    {
        public int IdUsuario { get; set; }//PK FK
        public cat_usuarios cat_usuarios { get; set; }
        public int IdRol { get; set; }//PK FK
        public seg_cat_roles seg_cat_roles { get; set; }
        public string UsuarioReg { get; set; }
        public Nullable<Int16> FechaReg { get; set; }
        public string UsuarioMod { get; set; }
        public Nullable<Int16> FechaUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//ok

    public class seg_cat_modulos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdModulo { get; set; } //PK
        [StringLength(100)]
        public string DesModulo { get; set; }
        public Nullable<Int16> Prioridad { get; set; }
        [StringLength(255)]
        public string RutaIcono { get; set; }
        [StringLength(10)]
        public string Version { get; set; }
        [StringLength(20)]
        public string Abreviatura { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }

    public class seg_cat_submodulos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdSubmodulo { get; set; } //PK
        public Int16 IdModulo { get; set; } //PK
        public seg_cat_modulos seg_cat_modulos { get; set; }
        [StringLength(100)]
        public string DesSubmodulo { get; set; }
        public Nullable<Int16> Prioridad { get; set; }
        [StringLength(255)]
        public string RutaIcono { get; set; }
        [StringLength(10)]
        public string Version { get; set; }
        [StringLength(20)]
        public string Abreviatura { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }

    public class seg_cat_paginas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdPagina { get; set; } //PK
        public Int16 IdModulo { get; set; }//FK
        public seg_cat_modulos seg_cat_modulos { get; set; }
        public Int16 IdSubmodulo { get; set; }//FK
        public seg_cat_submodulos seg_cat_submodulos { get; set; }
        [StringLength(50)]
        public string DesPagina { get; set; }
        [StringLength(500)]
        public string Detalle { get; set; }
        [StringLength(10)]
        public string Version { get; set; }
        public Nullable<Int16> Orden { get; set; }
        [StringLength(500)]
        public string RutaPagina { get; set; }
        [StringLength(255)]
        public string RutaImagen { get; set; }
        [StringLength(1)]
        public string Visible { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }

    public class seg_cat_mod_sub_pag
    {
        public List<seg_cat_modulos> seg_cat_modulos { get; set; }
        public List<seg_cat_submodulos> seg_cat_submodulos { get; set; }
        public List<seg_cat_paginas> seg_cat_paginas { get; set; }
    }

    public class temp_web_api_login
    {
        public cat_usuarios cat_usuarios { get; set; }
        public rh_cat_personas rh_cat_personas { get; set; }
        public seg_usuarios_estatus seg_usuarios_estatus { get; set; }
        public seg_expira_claves seg_expira_claves { get; set; }
        public rh_cat_dir_web rh_cat_dir_web { get; set; }
      //  public List<rh_cat_telefonos> list_telefonos { get; set; }
    }//ESTE MODELO TEMPORAL SIRVE PARA EL LOGIN

}//NAMESPACE
