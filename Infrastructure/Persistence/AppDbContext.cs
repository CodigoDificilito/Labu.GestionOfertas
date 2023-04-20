using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<TipoEstadoPostulacion> TipoEstadoPostulacion { get; set; }
        public DbSet<Oferta> oferta { get; set; }
        public DbSet<OfertaCategoria> OfertaCategoria { get; set; }
        public DbSet<Postulacion> Postulacion { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Precargar datos de Categoria desde el archivo JSON
            string directorioActual = Directory.GetCurrentDirectory();
            string rutaModficada = directorioActual.Replace("Labu", "");
            string rutaArchivoJson = Path.Combine(directorioActual, "Infrastructure", "Persistence", "CategoriaData.json");
            var categoriaJson = File.ReadAllText(rutaArchivoJson);
            var categorias = JsonConvert.DeserializeObject<List<Categoria>>(categoriaJson);

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.ToTable("Oferta");
                entity.HasKey(oi => oi.OfertaId);
                entity.Property(oi => oi.OfertaId)
                      .IsRequired();
                entity.Property(ei => ei.EmpresaId)
                      .IsRequired();
                entity.Property(t => t.Titulo)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(d => d.Descripcion)
                     .IsRequired()
                     .HasMaxLength(1500);
                entity.Property(s => s.Salario);
                entity.Property(ae => ae.AñosExperiencia);
                entity.Property(p => p.Provincia)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(c => c.Ciudad)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(ne => ne.NivelEstudios)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(f => f.Fecha)
                      .IsRequired();


                entity.HasMany<OfertaCategoria>(oc => oc.OfertaCategoria)
                      .WithOne(o => o.Oferta)
                      .HasForeignKey(oi => oi.OfertaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Postulacion>(p => p.Postulacion)
                      .WithOne(o => o.Oferta)
                      .HasForeignKey(oi => oi.OfertaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OfertaCategoria>(entity =>
            {
                entity.ToTable("OfertaCategoria");
                entity.HasKey(oci => oci.OfertaCategoriaId);
                entity.Property(oci => oci.OfertaCategoriaId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(oi => oi.OfertaId)
                      .IsRequired();
                entity.Property(ci => ci.CategoriaId)
                     .IsRequired();


                entity.HasOne<Oferta>(o => o.Oferta)
                      .WithMany(oc => oc.OfertaCategoria)
                      .HasForeignKey(oi => oi.OfertaId);

                entity.HasOne<Categoria>(c => c.Categoria)
                      .WithMany(oc => oc.OfertaCategoria)
                      .HasForeignKey(ci => ci.CategoriaId);
            });


            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categoria");
                entity.HasKey(ci => ci.CategoriaId);
                entity.Property(ci => ci.CategoriaId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Descripcion)
                     .IsRequired()
                     .HasMaxLength(50);


                entity.HasMany<OfertaCategoria>(oc => oc.OfertaCategoria)
                      .WithOne(c => c.Categoria)
                      .HasForeignKey(ci => ci.CategoriaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(

                       categorias);
                        
                        //new Categoria
                        //{
                        //    CategoriaId = 1,
                        //    Descripcion = "Tecnología"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 2,
                        //    Descripcion = "Marketing"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 3,
                        //    Descripcion = "Diseño"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 4,
                        //    Descripcion = "Administración"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 5,
                        //    Descripcion = "Finanzas"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 6,
                        //    Descripcion = "Recursos humanos"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 7,
                        //    Descripcion = "Ventas"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 8,
                        //    Descripcion = "Servicio al cliente"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 9,
                        //    Descripcion = "Logística"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 10,
                        //    Descripcion = "Producción"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 11,
                        //    Descripcion = "Educación"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 12,
                        //    Descripcion = "Salud"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 13,
                        //    Descripcion = "Investigación"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 14,
                        //    Descripcion = "Arte y cultura"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 15,
                        //    Descripcion = "Medios de comunicación"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 16,
                        //    Descripcion = "Derecho"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 17,
                        //    Descripcion = "Ingeniería"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 18,
                        //    Descripcion = "Ingeniería"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 19,
                        //    Descripcion = "Agricultura"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 20,
                        //    Descripcion = "Medio ambiente"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 21,
                        //    Descripcion = "Medio ambiente"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 22,
                        //    Descripcion = "Gastronomía"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 23,
                        //    Descripcion = "Gestión de proyectos"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 24,
                        //    Descripcion = "Consultoría"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 25,
                        //    Descripcion = "Análisis de datos"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 26,
                        //    Descripcion = "Química"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 27,
                        //    Descripcion = "Medicina"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 28,
                        //    Descripcion = "Enfermería"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 29,
                        //    Descripcion = "Psicología"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 30,
                        //    Descripcion = "Trabajo social"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 31,
                        //    Descripcion = "Arquitectura"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 32,
                        //    Descripcion = "Fotografía"
                        //},
                        //new Categoria
                        //{
                        //    CategoriaId = 33,
                        //    Descripcion = "Estadística"
                        //}

            });

            modelBuilder.Entity<Postulacion>(entity =>
            {
                entity.ToTable("Postulacion");
                entity.HasKey(pi => pi.PostulacionId);
                entity.Property(pi => pi.PostulacionId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ei => ei.EstadoId)
                      .IsRequired();
                entity.Property(ai => ai.AspiranteId)
                      .IsRequired();
                entity.Property(oi => oi.OfertaId)
                      .IsRequired();
                entity.Property(f => f.Fecha)
                     .IsRequired();


                entity.HasOne<Oferta>(o => o.Oferta)
                      .WithMany(p => p.Postulacion)
                      .HasForeignKey(oi => oi.OfertaId);

                entity.HasOne<TipoEstadoPostulacion>(tep => tep.TipoEstadoPostulacion)
                      .WithOne(p => p.Postulacion)
                      .HasForeignKey<Postulacion>(ei => ei.EstadoId);
            });

            modelBuilder.Entity<TipoEstadoPostulacion>(entity =>
            {
                entity.ToTable("TipoEstadoPostulacion");
                entity.HasKey(ei => ei.EstadoId);
                entity.Property(ei => ei.EstadoId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Descripcion)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasData(
                        new TipoEstadoPostulacion
                        {
                            EstadoId = 1,
                            Descripcion = "Postulado"
                        },
                        new TipoEstadoPostulacion
                        {
                            EstadoId = 2,
                            Descripcion = "CV Visto"
                        },
                        new TipoEstadoPostulacion
                        {
                            EstadoId = 3,
                            Descripcion = "En evaluación"
                        },
                        new TipoEstadoPostulacion
                        {
                            EstadoId = 4,
                            Descripcion = "Finalista"
                        }
                    );
            });
        }

    }
}
