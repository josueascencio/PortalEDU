using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class CambiandoTS_Por_Update_TodasLasTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ts",
                table: "TareaDocente");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "TareaAlumno");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "ResponsableAlumno");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "DocenteCurso");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "Docente");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "Ciclo");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "Ts",
                table: "AlumnoCurso");

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "TareaDocente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "TareaAlumno",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "ResponsableAlumno",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "ResponsableAlumno",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "DocenteCurso",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Docente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "Docente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Imagen",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "Curso",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "Ciclo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "Calificaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "update",
                table: "AlumnoCurso",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "update",
                table: "TareaDocente");

            migrationBuilder.DropColumn(
                name: "update",
                table: "TareaAlumno");

            migrationBuilder.DropColumn(
                name: "update",
                table: "ResponsableAlumno");

            migrationBuilder.DropColumn(
                name: "update",
                table: "DocenteCurso");

            migrationBuilder.DropColumn(
                name: "update",
                table: "Docente");

            migrationBuilder.DropColumn(
                name: "update",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "update",
                table: "Ciclo");

            migrationBuilder.DropColumn(
                name: "update",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "update",
                table: "AlumnoCurso");

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "TareaDocente",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "TareaAlumno",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "ResponsableAlumno",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "ResponsableAlumno",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "DocenteCurso",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Docente",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "Docente",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagen",
                table: "Curso",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "Curso",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "Ciclo",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "Calificaciones",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ts",
                table: "AlumnoCurso",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
