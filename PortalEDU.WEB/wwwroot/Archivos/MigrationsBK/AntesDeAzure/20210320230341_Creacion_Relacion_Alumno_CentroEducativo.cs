using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class Creacion_Relacion_Alumno_CentroEducativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCentroEducativo",
                table: "Alumno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdCentroEducativo",
                table: "Alumno",
                column: "IdCentroEducativo");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_CentroEducativo_IdCentroEducativo",
                table: "Alumno",
                column: "IdCentroEducativo",
                principalTable: "CentroEducativo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_CentroEducativo_IdCentroEducativo",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_IdCentroEducativo",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "IdCentroEducativo",
                table: "Alumno");
        }
    }
}
