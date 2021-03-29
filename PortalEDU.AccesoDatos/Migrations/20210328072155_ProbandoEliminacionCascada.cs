using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class ProbandoEliminacionCascada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_CentroEducativo_IdCentroEducativo",
                table: "Alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Aula_CentroEducativo_IdCentroEducativo",
                table: "Aula");

            migrationBuilder.DropForeignKey(
                name: "FK_CentroEducativo_Ciclo_IdAnioAcademico",
                table: "CentroEducativo");

            migrationBuilder.DropForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativo",
                table: "Docente");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_CentroEducativo_IdCentroEducativo",
                table: "Alumno",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_CentroEducativo_IdCentroEducativo",
                table: "Aula",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CentroEducativo_Ciclo_IdAnioAcademico",
                table: "CentroEducativo",
                column: "IdAnioAcademico",
                principalTable: "Ciclo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativo",
                table: "Docente",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_CentroEducativo_IdCentroEducativo",
                table: "Alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Aula_CentroEducativo_IdCentroEducativo",
                table: "Aula");

            migrationBuilder.DropForeignKey(
                name: "FK_CentroEducativo_Ciclo_IdAnioAcademico",
                table: "CentroEducativo");

            migrationBuilder.DropForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativo",
                table: "Docente");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_CentroEducativo_IdCentroEducativo",
                table: "Alumno",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_CentroEducativo_IdCentroEducativo",
                table: "Aula",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CentroEducativo_Ciclo_IdAnioAcademico",
                table: "CentroEducativo",
                column: "IdAnioAcademico",
                principalTable: "Ciclo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_CentroEducativo_IdCentroEducativo",
                table: "Docente",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
