﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCocacolaNayWebSrv.Models.Seguridad
{

    public class cat_institutos
    {
        [Key]
        [Required]
        public Int16 IdInstituto { get; set; }
        [StringLength(50)]
        public string DesInstituto { get; set; }
        [StringLength(20)]
        public string Alias { get; set; }
        [StringLength(1)]
        public string Matriz { get; set; }
        [ForeignKey("cat_institutos")]
        public Nullable<Int16> IdInstitutoPadre { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenGiro { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenGiro { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class cat_institutos OK

    public class rh_cat_personas
    {
        [Key]
        [Required]
        public int IdPersona { get; set; }
        [ForeignKey("cat_institutos")]
        public Nullable<Int16> IdInstituto { get; set; }
        [StringLength(20)]
        public string NumControl { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(60)]
        public string ApPaterno { get; set; }
        [StringLength(60)]
        public string ApMaterno { get; set; }
        [StringLength(15)]
        public string RFC { get; set; }
        [StringLength(25)]
        public string CURP { get; set; }
        public Nullable<DateTime> FechaNac { get; set; }
        [StringLength(1)]
        public string TipoPersona { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(255)]
        public string RutaFoto { get; set; }
        [StringLength(20)]
        public string Alias { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenOcupacion { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenOcupacion { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenEstadoCivil { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenEstadoCivil { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class rh_cat_personas OK

    public class cat_usuarios
    {
        [Key]
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("rh_cat_personas")]
        public Nullable<int> IdPersona { get; set; }
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
    }//class cat_usuarios OK

    public class rh_cat_dir_web
    {
        [Key]
        [Required]
        public int IdDirWeb { get; set; }
        [StringLength(50)]
        public string DesDirWeb { get; set; }
        [StringLength(255)]
        public string DirWeb { get; set; }
        [StringLength(1)]
        public string Principal { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenDirWeb { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenDirWeb { get; set; }
        [StringLength(50)]
        public string ClaveReferencia { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }
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
    }//class rh_cat_dir_web OK

    public class rh_cat_telefonos
    {
        [Key]
        [Required]
        public int IdTelefono { get; set; }
        [StringLength(2)]
        public string CodPais { get; set; }
        [StringLength(20)]
        public string NumTelefono { get; set; }
        [StringLength(30)]
        public string NumExtension { get; set; }
        [StringLength(1)]
        public string Principal { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdTipoGenTelefono { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenTelefono { get; set; }
        [StringLength(50)]
        public string ClaveReferencia { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }
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
    }//class rh_cat_telefonos OK

    public class cat_tipos_generales
    {
        [Key]
        [Required]
        public Int16 IdTipoGeneral { get; set; }
        [StringLength(100)]
        public string DesTipo { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class cat_tipos_generales OK

    public class cat_generales
    {
        [Key]
        [Required]
        public Int16 IdGeneral { get; set; }
        [ForeignKey("cat_tipos_generales")]
        [Required]
        public Int16 IdTipoGeneral { get; set; }
        [StringLength(20)]
        public string Clave { get; set; }
        [StringLength(100)]
        public string DesGeneral { get; set; }
        [StringLength(50)]
        public string IdLlaveClasifica { get; set; } //? debe ser int
        public Nullable<Int16> IdTipoGenClasifica { get; set; }
        public Nullable<Int16> IdGenClasifica { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class cat_generales OK

    public class cat_tipos_estatus
    {
        [Key]
        [Required]
        public int IdTipoEstatus { get; set; }
        [StringLength(30)]
        public string DesEstatus { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class cat_tipos_estatus OK

    public class cat_estatus
    {
        [Key]
        [Required]
        public int IdEstatus { get; set; }
        [ForeignKey("cat_tipos_estatus")]
        public Int16 IdTipoEstatus { get; set; }
        [StringLength(50)]
        public string Clave { get; set; }
        [StringLength(30)]
        public string DesEstatus { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class cat_estatus OK

    public class seg_expira_claves
    {
        [Key]
        [Required]
        public int IdClave { get; set; }
        [ForeignKey("cat_usuarios")]
        [Required]
        public int IdUsuario { get; set; }
        public Nullable<DateTime> FechaExpiraIni { get; set; }
        public Nullable<DateTime> FechaExpiraFin { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        [StringLength(20)]
        public string Clave { get; set; }
        [StringLength(1)]
        public string ClaveAutoSys { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class seg_expira_claves OK

    public class seg_usuarios_estatus
    {
        [Key]
        [Required]
        public int IdCrtlEstatus { get; set; }
        [ForeignKey("cat_usuarios")]
        [Required]
        public int IdUsuario { get; set; }
        public Nullable<DateTime> FechaEstatus { get; set; }
        [ForeignKey("cat_tipos_estatus")]
        public Nullable<Int16> IdTipoEstatus { get; set; }
        [ForeignKey("cat_estatus")]
        public Nullable<Int16> IdEstatus { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        [StringLength(500)]
        public string Observacion { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class seg_usuarios_estatus OK

    public class eva_cat_carreras
    {
        [Key]
        [Required]
        public Int16 IdCarrera { get; set; }
        [StringLength(20)]
        public string ClaveCarrera { get; set; }
        [StringLength(20)]
        public string ClaveOficial { get; set; }
        [StringLength(100)]
        public string DesCarrera { get; set; }
        [StringLength(10)]
        public string Alias { get; set; }
        [ForeignKey("rh_cat_areas_deptos")]
        public Nullable<Int16> IdAreaDepto { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenGradoEscolar { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenGradoEscolar { get; set; }
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
        [StringLength(20)]
        public string NombreCorto { get; set; }
        public Nullable<int> Creditos { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenModalidad { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenModalidad { get; set; }
        public Nullable<DateTime> FechaIni { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
    }//class eva_cat_carreras OK

    public class cat_periodos
    {
        [Key]
        [Required]
        public Int16 IdPeriodo { get; set; }
        [StringLength(100)]
        public string DesPeriodo { get; set; }
        [StringLength(30)]
        public string NombreCorto { get; set; }
        public Nullable<DateTime> PeriodoIni { get; set; }
        public Nullable<DateTime> PeriodoFin { get; set; }
        public Nullable<Int16> Año { get; set; }
        [StringLength(1)]
        public string NumPeriodo { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenPeriodo { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenPeriodo { get; set; }
        [StringLength(5)]
        public string ClavePeriodo { get; set; }
        public Nullable<Int16> NumDias { get; set; }
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
    }//class cat_periodos OK

    public class rh_cat_alumnos
    {
        [Key]
        [Required]
        [ForeignKey("rh_cat_personas")]
        public int IdAlumno { get; set; }
        [StringLength(20)]
        public string NumControl { get; set; }
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
        [ForeignKey("eva_cat_carreras")]
        public Nullable<Int16> IdCarrera { get; set; }
    }//class rh_cat_alumnos OK

    public class rh_cat_areas_deptos
    {
        [Key]
        [Required]
        public Int16 IdAreaDepto { get; set; }
        [StringLength(255)]
        public string DesArea { get; set; }
        [StringLength(20)]
        public string ClaveArea { get; set; }
        [StringLength(10)]
        public string NoArea { get; set; }
        [ForeignKey("rh_cat_areas_deptos")]
        public Nullable<Int16> IdAreaDeptoPadre { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenArea { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenArea { get; set; }
        public Nullable<Int16> Nivel { get; set; }
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
    }//class rh_cat_areas_deptos OK

    public class eva_cat_asignaturas
    {
        [Key]
        [Required]
        public Int16 IdAsignatura { get; set; }
        [StringLength(50)]
        public string ClaveAsignatura { get; set; }
        [StringLength(150)]
        public string DesAsignatura { get; set; }
        [StringLength(10)]
        public string Matricula { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        public Nullable<DateTime> FechaPlanEstudios { get; set; }
        [StringLength(100)]
        public string NombreCorto { get; set; }
        [StringLength(18)]
        public string Creditos { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenAsignatura { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenAsignatura { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenNivelEscolar { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenNivelEscolar { get; set; }
        [ForeignKey("rh_cat_areas_deptos")]
        public Nullable<Int16> IdAreaDepto { get; set; }
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
    }//class eva_cat_asignaturas OK

    public class eva_cat_carreras_reticulas
    {
        [Key]
        [Required]
        public int IdReticula { get; set; }
        [ForeignKey("eva_cat_carreras")]
        [Required]
        public Nullable<Int16> IdCarrera { get; set; }
        [StringLength(20)]
        public string Clave { get; set; }
        [StringLength(100)]
        public string DesReticula { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        public Nullable<DateTime> FechaIni { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenPlanEstudios { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenPlanEstudios { get; set; }
    }//class eva_cat_carreras_reticulas OK

    public class cat_periodos_actividades
    {
        [Key]
        [Required]
        public Int16 IdActividad { get; set; }
        [ForeignKey("cat_periodos")]
        [Required]
        public Int16 IdPeriodo { get; set; }
        [StringLength(200)]
        public string DesActividad { get; set; }
        public Nullable<DateTime> FechaIni { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenDia { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenDia { get; set; }
        [StringLength(1000)]
        public string Justificacion { get; set; }
        [StringLength(3000)]
        public string Mensaje { get; set; }
        [StringLength(1)]
        public string SeLabora { get; set; }
        public Nullable<DateTime> VerAPartirDe { get; set; }
        public Nullable<DateTime> VerHasta { get; set; }
        [StringLength(500)]
        public string RutaImagen { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
    }//class cat_periodos_actividades OK

    public class eva_cat_edificios
    {
        [Key]
        [Required]
        public Int16 IdEdificio { get; set; }
        [StringLength(10)]
        public string Alias { get; set; }
        [StringLength(50)]
        public string DesEdificio { get; set; }
        public Nullable<Int16> Prioridad { get; set; }
        [StringLength(20)]
        public string Clave { get; set; }
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
    }//class eva_cat_edificios OK

    public class eva_cat_espacios
    {
        [Key]
        [Required]
        public Int16 IdEspacio { get; set; }
        [ForeignKey("eva_cat_edificios")]
        [Required]
        public Int16 IdEdificio { get; set; }
        [StringLength(20)]
        public string Clave { get; set; }
        [StringLength(50)]
        public string DesEspacio { get; set; }
        public Nullable<Int16> Prioridad { get; set; }
        [StringLength(10)]
        public string Alias { get; set; }
        public Nullable<Int16> RangoTiempoReserva { get; set; }
        public Nullable<Int16> Capacidad { get; set; }
        public Nullable<Int16> IdTipoEstatus { get; set; }
        public Nullable<Int16> IdEstatus { get; set; }
        [StringLength(255)]
        public string RefeUbicacion { get; set; }
        [StringLength(1)]
        public string PermiteCruce { get; set; }
        [StringLength(20)]
        public string Observacion { get; set; }
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
    }//class eva_cat_espacios

    public class eva_grupos
    {
        [Key]
        [Required]
        public int IdGrupoHorario { get; set; }
        [ForeignKey("cat_periodos")]
        public Nullable<Int16> IdPeriodo { get; set; }
        [ForeignKey("eva_cat_carreras")]
        public Nullable<Int16> IdCarrera { get; set; }
        [ForeignKey("eva_cat_carreras_reticulas")]
        public Nullable<int> IdReticula { get; set; }
        [ForeignKey("eva_cat_asignaturas")]
        public Nullable<Int16> IdAsignatura { get; set; }
        [StringLength(5)]
        public string Grupo { get; set; }
        public Nullable<DateTime> FechaIni { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
        [ForeignKey("cat_tipos_estatus")]
        public Nullable<Int16> IdTipoEstatus { get; set; }
        [ForeignKey("cat_estatus")]
        public Nullable<Int16> IdEstatus { get; set; }
        [ForeignKey("cat_periodos_actividades")]
        public Nullable<Int16> IdActividad { get; set; }/*cambiar*/
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenHorario { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenHorario { get; set; }
        public Nullable<Int16> Capacidad { get; set; }
        public Nullable<Int16> AlumnosInscritos { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
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
    }//class eva_grupos OK

    public class eva_grupos_horarios
    {
        [Key]
        [Required]
        public int IdGrupoHorario { get; set; }
        [ForeignKey("cat_periodos")]
        [Required]
        public Nullable<Int16> IdPeriodo { get; set; }
        [Required]
        public Nullable<int> IdHorario { get; set; } /*CHECAR*/
        [ForeignKey("eva_cat_edificios")]
        public Nullable<Int16> IdEdificio { get; set; }
        [ForeignKey("eva_cat_espacios")]
        public Nullable<Int16> IdEspacio { get; set; }
        [StringLength(1)]
        public string Dia { get; set; }
        public Nullable<DateTime> HoraIni { get; set; }
        public Nullable<DateTime> HoraFin { get; set; }
        public Nullable<Int16> ToleraIni { get; set; }
        public Nullable<Int16> ToleraFin { get; set; }
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
    }//class eva_grupos_horarios OK

    public class eva_grupos_alumnos
    {
        [Key]
        [Required]
        [ForeignKey("eva_grupos")]
        public int IdGrupoHorario { get; set; }
        [ForeignKey("eva_grupos")]
        [Required]
        public Int16 IdPeriodo { get; set; }
        [ForeignKey("rh_cat_alumnos")]
        [Required]
        public int IdAlumno { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<Int16> Semestre { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(1)]
        public string EnRepeticion { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//class eva_grupos_alumnos OK

    public class bec_beacons_personas
    {
        [ForeignKey("bec_cat_beacons")]
        [Required]
        public int IdBeacon { get; set; }
        [Key]
        [ForeignKey("rh_cat_personas")]
        [Required]
        public int IdPersona { get; set; }
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
    }//bec_beacons_personas

    public class bec_cat_beacons
    {
        [Key]
        [Required]
        public int IdBeacon { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenBeacon { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenBeacon { get; set; }
        public Nullable<double> Minor { get; set; }
        public Nullable<double> Major { get; set; }
        public Nullable<double> FrecuenciaFX { get; set; }
        public Nullable<double> TransmisionTX { get; set; }
        [StringLength(20)]
        public string NomBeacon { get; set; }
        [StringLength(20)]
        public string ProximityFrame { get; set; }
        public Nullable<int> SignalStrength { get; set; }
        [StringLength(20)]
        public string MacAddress { get; set; }
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
    }//class bec_cat_beacons OK

    public class bec_reg_asistencia_espacios
    {
        [Key]
        [Required]
        public int IdRegAsistencia { get; set; }
        [ForeignKey("bec_cat_beacons")]
        public int IdBeacon { get; set; }
        [ForeignKey("cat_periodos")]
        public Nullable<Int16> IdPeriodo { get; set; }
        [ForeignKey("eva_cat_asignaturas")]
        public Nullable<Int16> IdAsignatura { get; set; }
        public Nullable<DateTime> FechaHoraIni { get; set; }
        public Nullable<DateTime> FechaHoraFin { get; set; }
        [StringLength(1)]
        public string DiaSemana { get; set; }
        public Nullable<DateTime> HoraOficial { get; set; }
        [StringLength(1)]
        public string Reportar { get; set; }
        public Nullable<Int16> ToleranciaEntrada { get; set; }
        public Nullable<Int16> ToleranciaSalida { get; set; }
        [StringLength(1)]
        public string RegistroOptimo { get; set; }
        [StringLength(200)]
        public string DiasHorasIniFin { get; set; }
        public Nullable<Int16> Minutos { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenAsistencia { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenAsistencia { get; set; }
        [StringLength(50)]
        public string Justificacion { get; set; }
        [StringLength(200)]
        public string Observacion { get; set; }
        [ForeignKey("rh_cat_personas")]
        public Nullable<int> IdPersona { get; set; }
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
        public Nullable<int> IdRegAsistOrigen { get; set; }
    }//class bec_reg_asistencia_espacios OK

    public class seg_cat_modulos
    {
        [Key]
        [Required]
        public Int16 IdModulo { get; set; }
        [StringLength(100)]
        public string DesModulo { get; set; }
        public Nullable<Int16> Prioridad { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(255)]
        public string RutaIcono { get; set; }
        [StringLength(10)]
        public string Version { get; set; }
        [StringLength(20)]
        public string Abreviatura { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//seg_cat_modulos Ok

    public class seg_cat_submodulos
    {
        [ForeignKey("seg_cat_modulos")]
        [Required]
        public Int16 IdModulo { get; set; }
        [Key]
        [Required]
        public Int16 IdSubmodulo { get; set; }
        [StringLength(100)]
        public string DesSubmodulo { get; set; }
        [StringLength(20)]
        public string Abreviatura { get; set; }
        public Nullable<Int16> Prioridad { get; set; }
        [StringLength(255)]
        public string RutaIcono { get; set; }
        [StringLength(10)]
        public string Version { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//seg_cat_submodulos OK

    public class seg_cat_paginas
    {
        [Key]
        [Required]
        public Int16 IdPagina { get; set; }
        [ForeignKey("seg_cat_modulos")]
        [Required]
        public Int16 IdModulo { get; set; }
        [ForeignKey("seg_cat_submodulos")]
        [Required]
        public Int16 IdSubmodulo { get; set; }
        [StringLength(500)]
        public string DesPagina { get; set; }
        [StringLength(10)]
        public string Version { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public Nullable<Int16> Orden { get; set; }
        [StringLength(500)]
        public string RutaPagina { get; set; }
        [StringLength(255)]
        public string RutaImagen { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Visible { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//seg_cat_paginas OK

    public class seg_cat_roles
    {
        [Key]
        [Required]
        public int IdRol { get; set; }
        [StringLength(200)]
        public string DesRol { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        public Nullable<int> DefaultDiasActivo { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Nullable<Int16> IdTipoGenRol { get; set; }
        [ForeignKey("cat_generales")]
        public Nullable<Int16> IdGenRol { get; set; }
        [StringLength(1000)]
        public string Observacion { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//seg_cat_roles OK
    public class cat_parametros
    {
        [Key]
        [Required]
        public Int16 IdParametro { get; set; }
        [StringLength(1000)]
        public string DesParametro { get; set; }
        [StringLength(7000)]
        public string Valor { get; set; }
        [StringLength(1)]
        public string TipoDato { get; set; }
        [ForeignKey("cat_tipos_generales")]
        public Int16 IdTipoGenParametro { get; set; }
        [ForeignKey("cat_generales")]
        public Int16 IdGenParametro { get; set; }
        [StringLength(5000)]
        public string Configuracion { get; set; }
        [StringLength(500)]
        public string Observacion { get; set; }
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

    }


    public class seg_roles_areas
    {
        [Required]
        public Int16 IdAreaDepto { get; set; }
        public int IdRol { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
    }

    public class temp_usuario_seguridad
    {
        //DE LA TABLA -> cat_usuarios
        public string Usuario { get; set; }
        //DE LA TABLA -> rh_cat_personas
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Alias { get; set; }
        public string NumControl { get; set; }
        public string Sexo { get; set; }
        public string RutaFoto { get; set; }
        //DE LA TABLA -> rh_cat_dir_web
        public string Correo { get; set; }
        //DE LA TABLA -> cat_generales
        public string DesGeneral { get; set; }
        //DE LA TABLA -> rh_cat_telefonos
        public string CodPais { get; set; }
        public string NumTelefono { get; set; }
        public string NumExtension { get; set; }
    }

    public class temp_usuario_asistencia
    {
        [Key]
        public int Id { get; set; }
        //DE LA TABLA -> cat_usuarios
        public string Usuario { get; set; }
        //DE LA TABLA -> eva_cat_carreras
        public string DesCarrera { get; set; }
        //DE LA TABLA -> rh_cat_personas
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        //DE LA TABLA -> cat_periodos
        public string DesPeriodo { get; set; }
    }

    public class seg_cat_usuarios
    {
        /*DE LA TABLA CAT_USUARIOS*/
        public int IdUsuario { get; set; }
        public rh_cat_personas IdPersona { get; set; }//public Nullable<int> IdPersona { get; set; }
        public string Usuario { get; set; }
        public string Expira { get; set; }
        public string Conectado { get; set; }
        public Nullable<DateTime> FechaAlta { get; set; }
        public Nullable<Int16> NumIntentos { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
        public List<seg_expira_claves> ListClaves { get; set; }
    }//TABLA PIVOTE PARA JSON MULTIDIMENCIONAL
}
