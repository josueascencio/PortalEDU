using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class PruebaCOdigoCE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoCE",
                table: "CentroEducativo",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoCE",
                table: "Alumno",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoCE",
                table: "CentroEducativo");

            migrationBuilder.DropColumn(
                name: "CodigoCE",
                table: "Alumno");
        }
    }
}
