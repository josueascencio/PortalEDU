using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class nullAlumnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Responsable_IdResponsable",
                table: "Alumno");

            migrationBuilder.AlterColumn<int>(
                name: "IdResponsable",
                table: "Alumno",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Responsable_IdResponsable",
                table: "Alumno",
                column: "IdResponsable",
                principalTable: "Responsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Responsable_IdResponsable",
                table: "Alumno");

            migrationBuilder.AlterColumn<int>(
                name: "IdResponsable",
                table: "Alumno",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Responsable_IdResponsable",
                table: "Alumno",
                column: "IdResponsable",
                principalTable: "Responsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
