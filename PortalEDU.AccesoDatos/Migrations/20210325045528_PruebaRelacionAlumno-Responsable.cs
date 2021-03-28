using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class PruebaRelacionAlumnoResponsable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsableAlumno");

            migrationBuilder.AddColumn<int>(
                name: "IdResponsable",
                table: "Alumno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResponsaId",
                table: "Alumno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profesion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_ResponsaId",
                table: "Alumno",
                column: "ResponsaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Responsable_ResponsaId",
                table: "Alumno",
                column: "ResponsaId",
                principalTable: "Responsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Responsable_ResponsaId",
                table: "Alumno");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_ResponsaId",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "IdResponsable",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "ResponsaId",
                table: "Alumno");

            migrationBuilder.CreateTable(
                name: "ResponsableAlumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAlumno = table.Column<int>(type: "int", nullable: false),
                    IdAlumnoNavigationId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profesion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableAlumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsableAlumno_Alumno_IdAlumnoNavigationId",
                        column: x => x.IdAlumnoNavigationId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableAlumno_IdAlumnoNavigationId",
                table: "ResponsableAlumno",
                column: "IdAlumnoNavigationId");
        }
    }
}
