using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppCocacolaNayWebSrv.Models.Inventarios;
using AppCocacolaNayWebSrv.Models.Seguridad;

namespace AppCocacolaNayWebSrv.Models
{
    public class FicDBContext : DbContext
    {
        public FicDBContext(DbContextOptions<FicDBContext> options)
            : base(options)
        {
        }//constructor

        public FicDBContext()
        {
        }//constructor

        public DbSet<cat_usuarios> cat_usuarios { get; set; }
        public DbSet<seg_expira_claves> seg_expira_claves { get; set; }
        public DbSet<seg_usuarios_estatus> seg_usuarios_estatus { get; set; }
        public DbSet<cat_estatus> cat_estatus { get; set; }
        public DbSet<rh_cat_personas> rh_cat_personas { get; set; }
        public DbSet<cat_generales> cat_generales { get; set; }
        public DbSet<rh_cat_dir_web> rh_cat_dir_web { get; set; }
        public DbSet<rh_cat_telefonos> rh_cat_telefonos { get; set; }
        public DbSet<eva_cat_carreras> eva_cat_carreras { get; set; }
        public DbSet<rh_cat_alumnos> rh_cat_alumnos { get; set; }
        public DbSet<cat_periodos> cat_periodos { get; set; }
        public DbSet<rh_cat_areas_deptos> rh_cat_areas_deptos { get; set; }
        public DbSet<eva_cat_asignaturas> eva_cat_asignaturas { get; set; }
        public DbSet<cat_institutos> cat_institutos { get; set; }
        public DbSet<bec_cat_beacons> bec_cat_beacons { get; set; }
        public DbSet<cat_tipos_generales> cat_tipos_generales { get; set; }
        public DbSet<eva_grupos_alumnos> eva_grupos_alumnos { get; set; }
        public DbSet<eva_grupos> eva_grupos { get; set; }
        public DbSet<bec_reg_asistencia_espacios> bec_reg_asistencia_espacios { get; set; }
        public DbSet<bec_beacons_personas> bec_beacons_personas { get; set; }
        public DbSet<cat_parametros> cat_parametros { get; set; }



        //Gestion de Inventarios
        public DbSet<zt_inventarios> zt_inventarios { get; set; }
        public DbSet<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public DbSet<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
        //Catalogos Unidades de Medida
        public DbSet<zt_cat_productos> zt_cat_productos { get; set; }
        public DbSet<zt_cat_unidad_medidas> zt_cat_unidad_medidas { get; set; }
        public DbSet<zt_cat_productos_medidas> zt_cat_productos_medidas { get; set; }
        //Catalogo CEDIS y Almacenes
        public DbSet<zt_cat_cedis> zt_cat_cedis { get; set; }
        public DbSet<zt_cat_almacenes> zt_cat_almacenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                /*CREACION DE LLAVES PRIMARIAS*/
                modelBuilder.Entity<zt_cat_cedis>()
                    .HasKey(c => new { c.IdCEDI });

                modelBuilder.Entity<zt_cat_almacenes>()
                    .HasKey(c => new { c.IdAlmacen });

                modelBuilder.Entity<zt_cat_productos>()
                    .HasKey(c => new { c.IdSKU });

                modelBuilder.Entity<zt_cat_unidad_medidas>()
                    .HasKey(c => new { c.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios>()
                    .HasKey(c => new { c.IdInventario });

                modelBuilder.Entity<zt_inventarios_conteos>()
                    .HasKey(c => new { c.NumConteo, c.IdInventario, c.IdAlmacen, c.IdSKU, c.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.NumConteo).IsUnique(false);

                modelBuilder.Entity<zt_cat_productos_medidas>()
                    .HasKey(c => new { c.IdSKU, c.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                   .HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida });

                /*CREACION DE LLAVES FORANEAS*/
                modelBuilder.Entity<zt_cat_almacenes>()
                .HasOne(s => s.zt_cat_cedis).
                WithMany().HasForeignKey(s => new { s.IdCEDI });

                modelBuilder.Entity<zt_inventarios>()
                .HasOne(s => s.zt_cat_cedis).
                WithMany().HasForeignKey(s => new { s.IdCEDI });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_inventarios).
                WithMany().HasForeignKey(s => new { s.IdInventario });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_almacenes).
                WithMany().HasForeignKey(s => new { s.IdAlmacen });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });

                modelBuilder.Entity<zt_cat_productos_medidas>()
                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_cat_productos_medidas>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                .HasOne(s => s.zt_inventarios).
                WithMany().HasForeignKey(s => new { s.IdInventario });

                modelBuilder.Entity<zt_inventarios_acumulados>()

                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });
            }
            catch (Exception e)
            {
                //await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
    }//class
}//nameespace
