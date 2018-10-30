﻿using AppCocacolaNayWebSrv.Models.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCocacolaNayWebSrv.Models.Inventarios
{
    public class zt_cat_cedis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCEDI { get; set; }
        [StringLength(50)]
        public string DesCEDI { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//OK

    public class zt_cat_almacenes
    {
        [StringLength(20)]
        public string IdAlmacen { get; set; }//PK
        public Int16 IdCEDI { get; set; }
        public zt_cat_cedis zt_cat_cedis { get; set; }
        [StringLength(50)]
        public string DesAlmacen { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//OK

    public class zt_cat_grupos_sku
    {
        [StringLength(20)]
        public string IdGrupoSKU { get; set; }//pk
        [StringLength(50)]
        public string DesGrupoSKU { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//ok

    public class zt_cat_productos
    {
        [StringLength(20)]
        public string IdSKU { get; set; }
        [StringLength(20)]
        public string IdGrupoSKU { get; set; }//fk
        public zt_cat_grupos_sku zt_cat_grupos_sku { get; set; }
        [StringLength(10)]
        public string IdUMedidaBase { get; set; }//fk
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
        [StringLength(20)]
        public string CodigoBarras { get; set; }
        [StringLength(50)]
        public string DesSKU { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//OK

    public class zt_cat_unidad_medidas
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(10)]
        // public Int16 IdUnidadMedida { get; set; }
        public string IdUnidadMedida { get; set; }
        [StringLength(20)]
        public string DesUMedida { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//ok

    public class zt_cat_estatus
    {
        [StringLength(20)]
        public string IdEstatus { get; set; }
        [StringLength(30)]
        public string DesEstatus { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
    }//ok

    public class zt_inventarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdInventario { get; set; }
        [StringLength(20)]
        public string IdInventarioSAP { get; set; }
        public Int16 IdCEDI { get; set; }
        public zt_cat_cedis zt_cat_cedis { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }//PK FK
        public zt_cat_almacenes zt_cat_almacenes { get; set; }
        [StringLength(20)]
        public string IdEstatus { get; set; }//fk
        public zt_cat_estatus zt_cat_estatus { get; set; }
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
    }//OK

    public class zt_inventarios_acumulados
    {
        public int IdInventario { get; set; }
        public zt_inventarios zt_inventarios { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public zt_cat_productos zt_cat_productos { get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
        public Nullable<double> CantidadTeorica { get; set; }
        public double CantidadTeoricaCJA { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public DateTime FechaReg { get; set; }
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

    public class zt_cat_ubicaciones
    {
        [StringLength(20)]
        public string IdUbicacion { get; set; }//pk
        [StringLength(50)]
        public string DesUbicacion { get; set; }//pk}
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//ok

    public class zt_almacenes_ubicaciones
    {
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        public zt_cat_almacenes zt_cat_almacenes { get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        public zt_cat_ubicaciones zt_cat_ubicaciones { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
    }//ok

    public class zt_inventarios_conteos
    {
        public int IdInventario { get; set; }
        public zt_inventarios zt_inventarios { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        public zt_cat_almacenes zt_cat_almacenes { get; set; }
        public int NumConteo { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public zt_cat_productos zt_cat_productos { get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
        [StringLength(20)]
        public string CodigoBarras { get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        public zt_cat_ubicaciones zt_cat_ubicaciones { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadPZA { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//ok

    public class zt_cat_productos_medidas
    {
        [StringLength(20)]
        public string IdSKU { get; set; }
        public zt_cat_productos zt_cat_productos { get; set; }
        public string IdUnidadMedida { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
        public double CantidadPZA { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//ok

    public class zt_inventatios_acumulados_conteos
    {
        public List<zt_inventarios> zt_inventarios { get; set; }
        public List<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public List<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
    }

    public class zt_inventarios_conteos_grid
    {
        public string IdInventario { get; set; }
        public string NumConteo { get; set; }
        public string IdAlmacen { get; set; }
        public string IdSKU { get; set; }
        public string CantidadFisica { get; set; }
        public string CantidadPZA { get; set; }
        public string IdUnidadMedida { get; set; }
        public string UsuarioReg { get; set; }
    }//ESTE MODELO SIRVE DE MANERA TEMPORAL

    public class temp_generales
    {
        public List<zt_cat_grupos_sku> zt_cat_grupos_sku { get; set; }
        public List<zt_cat_productos> zt_cat_productos { get; set; }
        public List<zt_cat_unidad_medidas> zt_cat_unidad_medidas { get; set; }
        public List<zt_cat_productos_medidas> zt_cat_productos_medidas { get; set; }
        public List<zt_cat_cedis> zt_cat_cedis { get; set; }
        public List<zt_cat_almacenes> zt_cat_almacenes { get; set; }
        public List<zt_cat_ubicaciones> zt_cat_ubicaciones { get; set; }
        public List<zt_almacenes_ubicaciones> zt_almacenes_ubicaciones { get; set; }
        public List<zt_cat_estatus> zt_cat_estatus { get; set; }

    }

    public class seg_cat_mod_sub_pag
    {
        public List<seg_cat_modulos> seg_cat_modulos { get; set; }
        public List<seg_cat_submodulos> seg_cat_submodulos { get; set; }
        public List<seg_cat_paginas> seg_cat_paginas { get; set; }
    }
}
