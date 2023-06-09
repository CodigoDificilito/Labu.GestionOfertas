﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Experiencia",
                columns: table => new
                {
                    ExperienciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencia", x => x.ExperienciaId);
                });

            migrationBuilder.CreateTable(
                name: "NivelEstudios",
                columns: table => new
                {
                    NivelEstudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelEstudios", x => x.NivelEstudioId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEstadoPostulacion",
                columns: table => new
                {
                    TipoEstadoPostulacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstadoPostulacion", x => x.TipoEstadoPostulacionId);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    OfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Salario = table.Column<int>(type: "int", nullable: false),
                    ExperienciaId = table.Column<int>(type: "int", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    CuidadId = table.Column<int>(type: "int", nullable: false),
                    NivelEstudioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.OfertaId);
                    table.ForeignKey(
                        name: "FK_Oferta_Experiencia_ExperienciaId",
                        column: x => x.ExperienciaId,
                        principalTable: "Experiencia",
                        principalColumn: "ExperienciaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oferta_NivelEstudios_NivelEstudioId",
                        column: x => x.NivelEstudioId,
                        principalTable: "NivelEstudios",
                        principalColumn: "NivelEstudioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfertaCategoria",
                columns: table => new
                {
                    OfertaCategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaCategoria", x => x.OfertaCategoriaId);
                    table.ForeignKey(
                        name: "FK_OfertaCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfertaCategoria_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Postulacion",
                columns: table => new
                {
                    PostulacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEstadoPostulacionId = table.Column<int>(type: "int", nullable: false),
                    AspiranteId = table.Column<int>(type: "int", nullable: false),
                    OfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulacion", x => x.PostulacionId);
                    table.ForeignKey(
                        name: "FK_Postulacion_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Postulacion_TipoEstadoPostulacion_TipoEstadoPostulacionId",
                        column: x => x.TipoEstadoPostulacionId,
                        principalTable: "TipoEstadoPostulacion",
                        principalColumn: "TipoEstadoPostulacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Tecnología" },
                    { 2, "Marketing" },
                    { 3, "Diseño" },
                    { 4, "Administración" },
                    { 5, "Finanzas" },
                    { 6, "Recursos humanos" },
                    { 7, "Ventas" },
                    { 8, "Servicio al cliente" },
                    { 9, "Logística" },
                    { 10, "Producción" },
                    { 11, "Educación" },
                    { 12, "Salud" },
                    { 13, "Investigación" },
                    { 14, "Arte y cultura" },
                    { 15, "Medios de comunicación" },
                    { 16, "Derecho" },
                    { 17, "Profesorado" },
                    { 18, "Ingeniería" },
                    { 19, "Mecànica" },
                    { 20, "Agricultura" },
                    { 21, "Medio ambiente" },
                    { 22, "Gastronomía" },
                    { 23, "Gestión de proyectos" },
                    { 24, "Consultoría" },
                    { 25, "Análisis de datos" },
                    { 26, "Química" },
                    { 27, "Medicina" },
                    { 28, "Enfermería" },
                    { 29, "Psicología" },
                    { 30, "Trabajo social" },
                    { 31, "Arquitectura" },
                    { 32, "Fotografía" },
                    { 33, "Estadística" }
                });

            migrationBuilder.InsertData(
                table: "Experiencia",
                columns: new[] { "ExperienciaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sin Experiencia" },
                    { 2, "1 Año" },
                    { 3, "2 Años" },
                    { 4, "3 Años" },
                    { 5, "4 Años" },
                    { 6, "5 Años" },
                    { 7, "6 Años" },
                    { 8, "7 Años" },
                    { 9, "8 Años" }
                });

            migrationBuilder.InsertData(
                table: "NivelEstudios",
                columns: new[] { "NivelEstudioId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Primaria" },
                    { 2, "Secundaria" },
                    { 3, "Terciario" },
                    { 4, "Universitario" },
                    { 5, "Posgrado" },
                    { 6, "Master" },
                    { 7, "Doctorado" },
                    { 8, "Sin estudios" }
                });

            migrationBuilder.InsertData(
                table: "TipoEstadoPostulacion",
                columns: new[] { "TipoEstadoPostulacionId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Postulado" },
                    { 2, "CV Visto" },
                    { 3, "En evaluación" },
                    { 4, "Finalista" },
                    { 5, "Proceso finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Oferta",
                columns: new[] { "OfertaId", "CuidadId", "Descripcion", "EmpresaId", "ExperienciaId", "Fecha", "NivelEstudioId", "ProvinciaId", "Salario", "Status", "Titulo" },
                values: new object[,]
                {
                    { new Guid("1d394678-e0eb-4620-a1de-f01c7768ddb3"), 0, "Importante empresa Autopartista se encuentra en la búsqueda de Programador Robotista.", 1, 2, new DateTime(2023, 4, 22, 10, 27, 32, 895, DateTimeKind.Unspecified).AddTicks(6499), 4, 6, 200000, true, "Programador Robotista." },
                    { new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), 0, "Estamos en la búsqueda de Responsable general para empresa con negocios en rubro inmobiliario y de playas de estacionamiento.", 4, 3, new DateTime(2023, 4, 23, 10, 27, 32, 895, DateTimeKind.Unspecified).AddTicks(6499), 5, 6, 200000, true, "Administrador/ Contador." },
                    { new Guid("3da7995a-715f-40b8-8121-b2ffdee778b0"), 0, "Buscamos Desarrollador SQL Server Junior/SSR. para sumarse a importante empresa de producto IT, líder en la creación de soluciones para el sector de salud.", 2, 3, new DateTime(2023, 5, 22, 12, 13, 20, 71, DateTimeKind.Unspecified).AddTicks(9537), 4, 6, 220000, true, "Desarrollador SQL Server Jr/SSr" },
                    { new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), 0, "En Ecosistemas estamos en la búsqueda de un Administrador de Backups Ssr/Sr para sumarse a nuestro equipo", 3, 3, new DateTime(2023, 4, 22, 8, 5, 20, 446, DateTimeKind.Unspecified).AddTicks(6304), 3, 6, 250000, true, "Administrador de Infraestructura Ssr." },
                    { new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), 0, "Desde Ecosistemas nos encontramos en la búsqueda de un Analista Funcional Jr/Ssr, para sumarse al equipo de nuestro cliente, empresa agropecuaria.", 3, 2, new DateTime(2023, 4, 22, 7, 50, 18, 989, DateTimeKind.Unspecified).AddTicks(830), 3, 6, 200000, true, "Analista Funcional Jr o Ssr." },
                    { new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), 0, "En Ecosistemas, buscamos un Desarrollador Java Jr/Ssr para sumar al equipo de nuestro cliente, en relación directa con el mismo.", 3, 1, new DateTime(2023, 3, 22, 12, 11, 59, 975, DateTimeKind.Unspecified).AddTicks(193), 2, 6, 180000, true, "Desarrollador Java Jr." },
                    { new Guid("e058b366-f832-42dd-b001-647919fdfd66"), 0, "Buscamos Desarrollador .NET Junior/Ssr. para sumarse a importante empresa de producto IT, líder en la creación de soluciones para el sector de salud.", 1, 3, new DateTime(2023, 4, 22, 8, 5, 19, 374, DateTimeKind.Unspecified).AddTicks(9336), 4, 6, 200000, true, "Desarrollador .NET Junior/Ssr." },
                    { new Guid("ee69bf0e-735f-44ff-9712-96830fddbf3a"), 0, "Buscamos AUXLIAR DE OPERACIONES SISTEMAS.", 2, 1, new DateTime(2023, 4, 23, 8, 5, 19, 374, DateTimeKind.Unspecified).AddTicks(9336), 4, 6, 150000, true, "Analista programador/a de sistemas." },
                    { new Guid("f1b4f44e-05fb-4062-a247-6830964ef063"), 0, "Buscamos Desarrollador .NET Junior/Ssr. para sumarse a importante empresa de producto IT, líder en la creación de soluciones para el sector de salud.", 2, 1, new DateTime(2023, 3, 22, 8, 4, 50, 928, DateTimeKind.Unspecified).AddTicks(6762), 3, 6, 120000, true, "Desarrollador .NET Junior." }
                });

            migrationBuilder.InsertData(
                table: "OfertaCategoria",
                columns: new[] { "OfertaCategoriaId", "CategoriaId", "OfertaId", "Status" },
                values: new object[,]
                {
                    { 1, 1, new Guid("e058b366-f832-42dd-b001-647919fdfd66"), true },
                    { 2, 3, new Guid("e058b366-f832-42dd-b001-647919fdfd66"), true },
                    { 3, 1, new Guid("f1b4f44e-05fb-4062-a247-6830964ef063"), true },
                    { 4, 3, new Guid("f1b4f44e-05fb-4062-a247-6830964ef063"), true },
                    { 5, 1, new Guid("ee69bf0e-735f-44ff-9712-96830fddbf3a"), true },
                    { 6, 25, new Guid("ee69bf0e-735f-44ff-9712-96830fddbf3a"), true },
                    { 7, 33, new Guid("e058b366-f832-42dd-b001-647919fdfd66"), true },
                    { 8, 25, new Guid("3da7995a-715f-40b8-8121-b2ffdee778b0"), true },
                    { 9, 33, new Guid("3da7995a-715f-40b8-8121-b2ffdee778b0"), true },
                    { 10, 23, new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), true },
                    { 11, 25, new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), true },
                    { 12, 33, new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), true },
                    { 13, 4, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 14, 18, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 15, 23, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 16, 25, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 17, 31, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 18, 1, new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), true },
                    { 19, 4, new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), true },
                    { 20, 25, new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), true },
                    { 21, 18, new Guid("1d394678-e0eb-4620-a1de-f01c7768ddb3"), true },
                    { 22, 19, new Guid("1d394678-e0eb-4620-a1de-f01c7768ddb3"), true },
                    { 23, 4, new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), true },
                    { 24, 5, new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), true },
                    { 25, 24, new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_ExperienciaId",
                table: "Oferta",
                column: "ExperienciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_NivelEstudioId",
                table: "Oferta",
                column: "NivelEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCategoria_CategoriaId",
                table: "OfertaCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCategoria_OfertaId",
                table: "OfertaCategoria",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Postulacion_OfertaId",
                table: "Postulacion",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Postulacion_TipoEstadoPostulacionId",
                table: "Postulacion",
                column: "TipoEstadoPostulacionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertaCategoria");

            migrationBuilder.DropTable(
                name: "Postulacion");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "TipoEstadoPostulacion");

            migrationBuilder.DropTable(
                name: "Experiencia");

            migrationBuilder.DropTable(
                name: "NivelEstudios");
        }
    }
}
