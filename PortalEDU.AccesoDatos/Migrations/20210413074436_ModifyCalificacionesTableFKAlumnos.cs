using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class ModifyCalificacionesTableFKAlumnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCalificaciones",
                table: "Alumno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdCalificaciones",
                table: "Alumno",
                column: "IdCalificaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Calificaciones_IdCalificaciones",
                table: "Alumno",
                column: "IdCalificaciones",
                principalTable: "Calificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Calificaciones_IdCalificaciones",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_IdCalificaciones",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "IdCalificaciones",
                table: "Alumno");
        }
    }
}
