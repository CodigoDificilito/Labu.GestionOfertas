using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "Oferta",
                columns: table => new
                {
                    OfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Salario = table.Column<int>(type: "int", nullable: false),
                    AñosExperiencia = table.Column<int>(type: "int", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NivelEstudios = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.OfertaId);
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
                name: "OfertaCategoria",
                columns: table => new
                {
                    OfertaCategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaCategoria", x => x.OfertaCategoriaId);
                    table.ForeignKey(
                        name: "FK_OfertaCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaCategoria_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Cascade);
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
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulacion", x => x.PostulacionId);
                    table.ForeignKey(
                        name: "FK_Postulacion_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Cascade);
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
                    { 17, "Ingeniería" },
                    { 18, "Ingeniería" },
                    { 19, "Agricultura" },
                    { 20, "Medio ambiente" },
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
                table: "TipoEstadoPostulacion",
                columns: new[] { "TipoEstadoPostulacionId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Postulado" },
                    { 2, "CV Visto" },
                    { 3, "En evaluación" },
                    { 4, "Finalista" }
                });

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
        }
    }
}
