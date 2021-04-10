using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class Deletetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoCurso_Alumno_IdAlumnoNavigationId",
                table: "AlumnoCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoCurso_Curso_IdCursoNavigationId",
                table: "AlumnoCurso");

            migrationBuilder.DropTable(
                name: "Padre");

            migrationBuilder.DropTable(
                name: "UsuarioSesion");

            migrationBuilder.RenameColumn(
                name: "IdCursoNavigationId",
                table: "AlumnoCurso",
                newName: "CursoId");

            migrationBuilder.RenameColumn(
                name: "IdAlumnoNavigationId",
                table: "AlumnoCurso",
                newName: "AlumnoId");

            migrationBuilder.RenameIndex(
                name: "IX_AlumnoCurso_IdCursoNavigationId",
                table: "AlumnoCurso",
                newName: "IX_AlumnoCurso_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_AlumnoCurso_IdAlumnoNavigationId",
                table: "AlumnoCurso",
                newName: "IX_AlumnoCurso_AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoCurso_Alumno_AlumnoId",
                table: "AlumnoCurso",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoCurso_Curso_CursoId",
                table: "AlumnoCurso",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoCurso_Alumno_AlumnoId",
                table: "AlumnoCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoCurso_Curso_CursoId",
                table: "AlumnoCurso");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "AlumnoCurso",
                newName: "IdCursoNavigationId");

            migrationBuilder.RenameColumn(
                name: "AlumnoId",
                table: "AlumnoCurso",
                newName: "IdAlumnoNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_AlumnoCurso_CursoId",
                table: "AlumnoCurso",
                newName: "IX_AlumnoCurso_IdCursoNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_AlumnoCurso_AlumnoId",
                table: "AlumnoCurso",
                newName: "IX_AlumnoCurso_IdAlumnoNavigationId");

            migrationBuilder.CreateTable(
                name: "Padre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSesion",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSesion", x => x.IdUsuario);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoCurso_Alumno_IdAlumnoNavigationId",
                table: "AlumnoCurso",
                column: "IdAlumnoNavigationId",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoCurso_Curso_IdCursoNavigationId",
                table: "AlumnoCurso",
                column: "IdCursoNavigationId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
