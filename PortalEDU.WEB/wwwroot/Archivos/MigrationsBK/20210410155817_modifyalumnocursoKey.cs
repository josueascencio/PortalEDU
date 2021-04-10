using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class modifyalumnocursoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlumnoCurso",
                table: "AlumnoCurso");

            migrationBuilder.DropColumn(
                name: "IdCurso",
                table: "AlumnoCurso");

            migrationBuilder.RenameColumn(
                name: "update",
                table: "AlumnoCurso",
                newName: "Update");

            migrationBuilder.AlterColumn<int>(
                name: "IdAlumnoCurso",
                table: "AlumnoCurso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlumnoCurso",
                table: "AlumnoCurso",
                column: "IdAlumnoCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlumnoCurso",
                table: "AlumnoCurso");

            migrationBuilder.RenameColumn(
                name: "Update",
                table: "AlumnoCurso",
                newName: "update");

            migrationBuilder.AlterColumn<int>(
                name: "IdAlumnoCurso",
                table: "AlumnoCurso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdCurso",
                table: "AlumnoCurso",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlumnoCurso",
                table: "AlumnoCurso",
                column: "IdCurso");
        }
    }
}
