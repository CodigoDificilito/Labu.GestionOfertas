using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<TipoEstadoPostulacion> TipoEstadoPostulacion { get; set; }
        public DbSet<Oferta> Oferta { get; set; }
        public DbSet<OfertaCategoria> OfertaCategoria { get; set; }
        public DbSet<Postulacion> Postulacion { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<NivelEstudio> NivelEstudio { get; set; }

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

            string rutaArchivoTresJson = Path.Combine(directorioActual, "Infrastructure", "Persistence", "OfertasData.json");
            var ofertaJson = File.ReadAllText(rutaArchivoTresJson);
            var ofertas = JsonConvert.DeserializeObject<List<Oferta>>(ofertaJson);

            string rutaArchivoCuatroJson = Path.Combine(directorioActual, "Infrastructure", "Persistence", "OfertaCategoriaData.json");
            var OfertaCategoriaJson = File.ReadAllText(rutaArchivoCuatroJson);
            var ofertaCategorias = JsonConvert.DeserializeObject<List<OfertaCategoria>>(OfertaCategoriaJson);

            string rutaArchivoCincoJson = Path.Combine(directorioActual, "Infrastructure", "Persistence", "ExperienciaData.json");
            var ExperienciaJson = File.ReadAllText(rutaArchivoCincoJson);
            var experiencia = JsonConvert.DeserializeObject<List<Experiencia>>(ExperienciaJson);

            string rutaArchivoSeisJson = Path.Combine(directorioActual, "Infrastructure", "Persistence", "NivelEstudioData.json");
            var NivelEstudioJson = File.ReadAllText(rutaArchivoSeisJson);
            var nivelEstudio = JsonConvert.DeserializeObject<List<NivelEstudio>>(NivelEstudioJson);

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
                entity.Property(ae => ae.ExperienciaId);
                entity.Property(p => p.ProvinciaId)
                      .IsRequired();
                entity.Property(c => c.CuidadId)
                      .IsRequired();
                entity.Property(ne => ne.NivelEstudioId)
                      .IsRequired();
                entity.Property(f => f.Fecha)
                      .IsRequired();
                entity.Property(f => f.Status)
                      .IsRequired();


                entity.HasMany<OfertaCategoria>(oc => oc.OfertaCategoria)
                      .WithOne(o => o.Oferta)
                      .HasForeignKey(oi => oi.OfertaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany<Postulacion>(p => p.Postulacion)
                      .WithOne(o => o.Oferta)
                      .HasForeignKey(oi => oi.OfertaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Experiencia>(e => e.Experiencia)
                      .WithMany(o => o.Oferta)
                      .HasForeignKey(ei => ei.ExperienciaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<NivelEstudio>(ne => ne.NivelEstudio)
                      .WithMany(o => o.Oferta)
                      .HasForeignKey(nei => nei.NivelEstudioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(ofertas);
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
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(categorias);
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
                entity.Property(f => f.Status)
                      .IsRequired();

                entity.HasOne<Oferta>(o => o.Oferta)
                      .WithMany(oc => oc.OfertaCategoria)
                      .HasForeignKey(oi => oi.OfertaId);

                entity.HasOne<Categoria>(c => c.Categoria)
                      .WithMany(oc => oc.OfertaCategoria)
                      .HasForeignKey(ci => ci.CategoriaId);

                entity.HasData(ofertaCategorias);
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
                entity.Property(f => f.Status)
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

            modelBuilder.Entity<Experiencia>(entity =>
            {
                entity.ToTable("Experiencia");
                entity.HasKey(ei => ei.ExperienciaId);
                entity.Property(ei => ei.ExperienciaId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Nombre)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasMany<Oferta>(oc => oc.Oferta)
                      .WithOne(c => c.Experiencia)
                      .HasForeignKey(ci => ci.ExperienciaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(experiencia);
            });

            modelBuilder.Entity<NivelEstudio>(entity =>
            {
                entity.ToTable("NivelEstudios");
                entity.HasKey(nei => nei.NivelEstudioId);
                entity.Property(nei => nei.NivelEstudioId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Nombre)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasMany<Oferta>(oc => oc.Oferta)
                      .WithOne(c => c.NivelEstudio)
                      .HasForeignKey(ci => ci.NivelEstudioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(nivelEstudio);
            });
        }

    }
}
