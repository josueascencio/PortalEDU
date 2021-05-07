using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class Cambiando_Entidad_Alumno_Docente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativoNavigationId",
                table: "Docente");

            migrationBuilder.DropIndex(
                name: "IX_Docente_IdCentroEducativoNavigationId",
                table: "Docente");

            migrationBuilder.DropColumn(
                name: "FechaNacimeinto",
                table: "Docente");

            migrationBuilder.DropColumn(
                name: "IdCentroEducativoNavigationId",
                table: "Docente");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Docente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Alumno",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carnet",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Docente_IdCentroEducativo",
                table: "Docente",
                column: "IdCentroEducativo");

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativo",
                table: "Docente",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativo",
                table: "Docente");

            migrationBuilder.DropIndex(
                name: "IX_Docente_IdCentroEducativo",
                table: "Docente");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Docente");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimeinto",
                table: "Docente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCentroEducativoNavigationId",
                table: "Docente",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Alumno",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Carnet",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_IdCentroEducativoNavigationId",
                table: "Docente",
                column: "IdCentroEducativoNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativoNavigationId",
                table: "Docente",
                column: "IdCentroEducativoNavigationId",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
