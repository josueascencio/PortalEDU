using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class ModifyCalificacionesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Alumno_IdAlumnoNavigationId",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_IdAlumnoNavigationId",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "IdAlumnoNavigationId",
                table: "Calificaciones");

            migrationBuilder.RenameColumn(
                name: "update",
                table: "Calificaciones",
                newName: "Update");

            migrationBuilder.AlterColumn<decimal>(
                name: "TercerTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SegundoTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Promedio",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrimerTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CuartoTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdAlumno",
                table: "Calificaciones",
                column: "IdAlumno");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Alumno_IdAlumno",
                table: "Calificaciones",
                column: "IdAlumno",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Alumno_IdAlumno",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_IdAlumno",
                table: "Calificaciones");

            migrationBuilder.RenameColumn(
                name: "Update",
                table: "Calificaciones",
                newName: "update");

            migrationBuilder.AlterColumn<decimal>(
                name: "TercerTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SegundoTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Promedio",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrimerTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CuartoTrimestre",
                table: "Calificaciones",
                type: "decimal (18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAlumnoNavigationId",
                table: "Calificaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdAlumnoNavigationId",
                table: "Calificaciones",
                column: "IdAlumnoNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Alumno_IdAlumnoNavigationId",
                table: "Calificaciones",
                column: "IdAlumnoNavigationId",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
