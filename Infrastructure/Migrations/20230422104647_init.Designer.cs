﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230422104647_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Descripcion = "Tecnología"
                        },
                        new
                        {
                            CategoriaId = 2,
                            Descripcion = "Marketing"
                        },
                        new
                        {
                            CategoriaId = 3,
                            Descripcion = "Diseño"
                        },
                        new
                        {
                            CategoriaId = 4,
                            Descripcion = "Administración"
                        },
                        new
                        {
                            CategoriaId = 5,
                            Descripcion = "Finanzas"
                        },
                        new
                        {
                            CategoriaId = 6,
                            Descripcion = "Recursos humanos"
                        },
                        new
                        {
                            CategoriaId = 7,
                            Descripcion = "Ventas"
                        },
                        new
                        {
                            CategoriaId = 8,
                            Descripcion = "Servicio al cliente"
                        },
                        new
                        {
                            CategoriaId = 9,
                            Descripcion = "Logística"
                        },
                        new
                        {
                            CategoriaId = 10,
                            Descripcion = "Producción"
                        },
                        new
                        {
                            CategoriaId = 11,
                            Descripcion = "Educación"
                        },
                        new
                        {
                            CategoriaId = 12,
                            Descripcion = "Salud"
                        },
                        new
                        {
                            CategoriaId = 13,
                            Descripcion = "Investigación"
                        },
                        new
                        {
                            CategoriaId = 14,
                            Descripcion = "Arte y cultura"
                        },
                        new
                        {
                            CategoriaId = 15,
                            Descripcion = "Medios de comunicación"
                        },
                        new
                        {
                            CategoriaId = 16,
                            Descripcion = "Derecho"
                        },
                        new
                        {
                            CategoriaId = 17,
                            Descripcion = "Ingeniería"
                        },
                        new
                        {
                            CategoriaId = 18,
                            Descripcion = "Ingeniería"
                        },
                        new
                        {
                            CategoriaId = 19,
                            Descripcion = "Agricultura"
                        },
                        new
                        {
                            CategoriaId = 20,
                            Descripcion = "Medio ambiente"
                        },
                        new
                        {
                            CategoriaId = 21,
                            Descripcion = "Medio ambiente"
                        },
                        new
                        {
                            CategoriaId = 22,
                            Descripcion = "Gastronomía"
                        },
                        new
                        {
                            CategoriaId = 23,
                            Descripcion = "Gestión de proyectos"
                        },
                        new
                        {
                            CategoriaId = 24,
                            Descripcion = "Consultoría"
                        },
                        new
                        {
                            CategoriaId = 25,
                            Descripcion = "Análisis de datos"
                        },
                        new
                        {
                            CategoriaId = 26,
                            Descripcion = "Química"
                        },
                        new
                        {
                            CategoriaId = 27,
                            Descripcion = "Medicina"
                        },
                        new
                        {
                            CategoriaId = 28,
                            Descripcion = "Enfermería"
                        },
                        new
                        {
                            CategoriaId = 29,
                            Descripcion = "Psicología"
                        },
                        new
                        {
                            CategoriaId = 30,
                            Descripcion = "Trabajo social"
                        },
                        new
                        {
                            CategoriaId = 31,
                            Descripcion = "Arquitectura"
                        },
                        new
                        {
                            CategoriaId = 32,
                            Descripcion = "Fotografía"
                        },
                        new
                        {
                            CategoriaId = 33,
                            Descripcion = "Estadística"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Oferta", b =>
                {
                    b.Property<Guid>("OfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AñosExperiencia")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NivelEstudios")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Salario")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OfertaId");

                    b.ToTable("Oferta", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OfertaCategoria", b =>
                {
                    b.Property<int>("OfertaCategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfertaCategoriaId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<Guid>("OfertaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OfertaCategoriaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("OfertaId");

                    b.ToTable("OfertaCategoria", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Postulacion", b =>
                {
                    b.Property<int>("PostulacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostulacionId"));

                    b.Property<int>("AspiranteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OfertaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoEstadoPostulacionId")
                        .HasColumnType("int");

                    b.HasKey("PostulacionId");

                    b.HasIndex("OfertaId");

                    b.HasIndex("TipoEstadoPostulacionId")
                        .IsUnique();

                    b.ToTable("Postulacion", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoEstadoPostulacion", b =>
                {
                    b.Property<int>("TipoEstadoPostulacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoEstadoPostulacionId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoEstadoPostulacionId");

                    b.ToTable("TipoEstadoPostulacion", (string)null);

                    b.HasData(
                        new
                        {
                            TipoEstadoPostulacionId = 1,
                            Descripcion = "Postulado"
                        },
                        new
                        {
                            TipoEstadoPostulacionId = 2,
                            Descripcion = "CV Visto"
                        },
                        new
                        {
                            TipoEstadoPostulacionId = 3,
                            Descripcion = "En evaluación"
                        },
                        new
                        {
                            TipoEstadoPostulacionId = 4,
                            Descripcion = "Finalista"
                        });
                });

            modelBuilder.Entity("Domain.Entities.OfertaCategoria", b =>
                {
                    b.HasOne("Domain.Entities.Categoria", "Categoria")
                        .WithMany("OfertaCategoria")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Oferta", "Oferta")
                        .WithMany("OfertaCategoria")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("Domain.Entities.Postulacion", b =>
                {
                    b.HasOne("Domain.Entities.Oferta", "Oferta")
                        .WithMany("Postulacion")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoEstadoPostulacion", "TipoEstadoPostulacion")
                        .WithOne("Postulacion")
                        .HasForeignKey("Domain.Entities.Postulacion", "TipoEstadoPostulacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oferta");

                    b.Navigation("TipoEstadoPostulacion");
                });

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Navigation("OfertaCategoria");
                });

            modelBuilder.Entity("Domain.Entities.Oferta", b =>
                {
                    b.Navigation("OfertaCategoria");

                    b.Navigation("Postulacion");
                });

            modelBuilder.Entity("Domain.Entities.TipoEstadoPostulacion", b =>
                {
                    b.Navigation("Postulacion")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
