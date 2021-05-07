using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class AgregandoRefactorizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Aula_IdAulaNavigationId",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaAlumno_Alumno_IdAlumnoNavigationId",
                table: "TareaAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaAlumno_TareaDocente_IdTareaDocenteNavigationId",
                table: "TareaAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaDocente_Docente_IdDocenteNavigationId",
                table: "TareaDocente");

            migrationBuilder.DropIndex(
                name: "IX_TareaAlumno_IdAlumnoNavigationId",
                table: "TareaAlumno");

            migrationBuilder.DropIndex(
                name: "IX_TareaAlumno_IdTareaDocenteNavigationId",
                table: "TareaAlumno");

            migrationBuilder.DropIndex(
                name: "IX_Curso_IdAulaNavigationId",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "IdAlumnoNavigationId",
                table: "TareaAlumno");

            migrationBuilder.DropColumn(
                name: "IdTareaDocenteNavigationId",
                table: "TareaAlumno");

            migrationBuilder.DropColumn(
                name: "Aviso",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "IdAulaNavigationId",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Curso");

            migrationBuilder.RenameColumn(
                name: "update",
                table: "TareaDocente",
                newName: "Update");

            migrationBuilder.RenameColumn(
                name: "IdDocenteNavigationId",
                table: "TareaDocente",
                newName: "IdCurso");

            migrationBuilder.RenameIndex(
                name: "IX_TareaDocente_IdDocenteNavigationId",
                table: "TareaDocente",
                newName: "IX_TareaDocente_IdCurso");

            migrationBuilder.RenameColumn(
                name: "update",
                table: "TareaAlumno",
                newName: "Update");

            migrationBuilder.RenameColumn(
                name: "update",
                table: "Curso",
                newName: "Update");

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "TareaDocente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "TareaDocente",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "TareaAlumno",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TareaDocente_IdDocente",
                table: "TareaDocente",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_TareaAlumno_IdAlumno",
                table: "TareaAlumno",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_TareaAlumno_IdTareaDocente",
                table: "TareaAlumno",
                column: "IdTareaDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdAula",
                table: "Curso",
                column: "IdAula");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Aula_IdAula",
                table: "Curso",
                column: "IdAula",
                principalTable: "Aula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaAlumno_Alumno_IdAlumno",
                table: "TareaAlumno",
                column: "IdAlumno",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaAlumno_TareaDocente_IdTareaDocente",
                table: "TareaAlumno",
                column: "IdTareaDocente",
                principalTable: "TareaDocente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaDocente_Curso_IdCurso",
                table: "TareaDocente",
                column: "IdCurso",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaDocente_Docente_IdDocente",
                table: "TareaDocente",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Aula_IdAula",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaAlumno_Alumno_IdAlumno",
                table: "TareaAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaAlumno_TareaDocente_IdTareaDocente",
                table: "TareaAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaDocente_Curso_IdCurso",
                table: "TareaDocente");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaDocente_Docente_IdDocente",
                table: "TareaDocente");

            migrationBuilder.DropIndex(
                name: "IX_TareaDocente_IdDocente",
                table: "TareaDocente");

            migrationBuilder.DropIndex(
                name: "IX_TareaAlumno_IdAlumno",
                table: "TareaAlumno");

            migrationBuilder.DropIndex(
                name: "IX_TareaAlumno_IdTareaDocente",
                table: "TareaAlumno");

            migrationBuilder.DropIndex(
                name: "IX_Curso_IdAula",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "TareaDocente");

            migrationBuilder.RenameColumn(
                name: "Update",
                table: "TareaDocente",
                newName: "update");

            migrationBuilder.RenameColumn(
                name: "IdCurso",
                table: "TareaDocente",
                newName: "IdDocenteNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_TareaDocente_IdCurso",
                table: "TareaDocente",
                newName: "IX_TareaDocente_IdDocenteNavigationId");

            migrationBuilder.RenameColumn(
                name: "Update",
                table: "TareaAlumno",
                newName: "update");

            migrationBuilder.RenameColumn(
                name: "Update",
                table: "Curso",
                newName: "update");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Documento",
                table: "TareaDocente",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Documento",
                table: "TareaAlumno",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAlumnoNavigationId",
                table: "TareaAlumno",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTareaDocenteNavigationId",
                table: "TareaAlumno",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aviso",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAulaNavigationId",
                table: "Curso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TareaAlumno_IdAlumnoNavigationId",
                table: "TareaAlumno",
                column: "IdAlumnoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaAlumno_IdTareaDocenteNavigationId",
                table: "TareaAlumno",
                column: "IdTareaDocenteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdAulaNavigationId",
                table: "Curso",
                column: "IdAulaNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Aula_IdAulaNavigationId",
                table: "Curso",
                column: "IdAulaNavigationId",
                principalTable: "Aula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaAlumno_Alumno_IdAlumnoNavigationId",
                table: "TareaAlumno",
                column: "IdAlumnoNavigationId",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaAlumno_TareaDocente_IdTareaDocenteNavigationId",
                table: "TareaAlumno",
                column: "IdTareaDocenteNavigationId",
                principalTable: "TareaDocente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaDocente_Docente_IdDocenteNavigationId",
                table: "TareaDocente",
                column: "IdDocenteNavigationId",
                principalTable: "Docente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
