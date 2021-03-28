using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class ErrorEscrituraResponsable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Responsable_ResponsaId",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_ResponsaId",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "ResponsaId",
                table: "Alumno");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdResponsable",
                table: "Alumno",
                column: "IdResponsable");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Responsable_IdResponsable",
                table: "Alumno",
                column: "IdResponsable",
                principalTable: "Responsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Responsable_IdResponsable",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_IdResponsable",
                table: "Alumno");

            migrationBuilder.AddColumn<int>(
                name: "ResponsaId",
                table: "Alumno",
                type: "int",
                nullable: true);

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
    }
}
