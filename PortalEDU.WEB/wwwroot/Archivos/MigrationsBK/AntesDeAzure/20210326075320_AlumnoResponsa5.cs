using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class AlumnoResponsa5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Alumno_IdResponsable",
                table: "Alumno");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdResponsable",
                table: "Alumno",
                column: "IdResponsable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Alumno_IdResponsable",
                table: "Alumno");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdResponsable",
                table: "Alumno",
                column: "IdResponsable",
                unique: true);
        }
    }
}
