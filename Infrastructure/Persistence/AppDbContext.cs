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
            // Obtener la ruta de los Precargar datos de Categoria desde el archivo JSON
            string directorioActual = Directory.GetCurrentDirectory();
            directorioActual = directorioActual.Substring(0, directorioActual.Length - 5);

            string rutaArchivoUnoJson = Path.Combine(directorioActual, "Infrastructure", "Persistence", "CategoriaData.json");
            var categoriaJson = File.ReadAllText(rutaArchivoUnoJson);
            var categorias = JsonConvert.DeserializeObject<List<Categoria>>(categoriaJson);

            string rutaArchivoDosJson = Path.Combine(directorioActual, "Infrastructure", "Persistence", "TipoEstadoPostulacionData.json");
            var tipoEstadoJson = File.ReadAllText(rutaArchivoDosJson);
            var tipoEstados = JsonConvert.DeserializeObject<List<TipoEstadoPostulacion>>(tipoEstadoJson);

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

                entity.HasData(categorias);
            });


            modelBuilder.Entity<Postulacion>(entity =>
            {
                entity.ToTable("Postulacion");
                entity.HasKey(pi => pi.PostulacionId);
                entity.Property(pi => pi.PostulacionId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ei => ei.TipoEstadoPostulacionId)
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
                      .HasForeignKey<Postulacion>(ei => ei.TipoEstadoPostulacionId);
            });

            modelBuilder.Entity<TipoEstadoPostulacion>(entity =>
            {
                entity.ToTable("TipoEstadoPostulacion");
                entity.HasKey(ei => ei.TipoEstadoPostulacionId);
                entity.Property(ei => ei.TipoEstadoPostulacionId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Descripcion)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasData(tipoEstados);
            });
        }

    }
}
