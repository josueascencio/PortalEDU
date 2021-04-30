using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class RelacionSala_SalaComentario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "SalaComentario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDocente",
                table: "Sala",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdResponsable",
                table: "Sala",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaComentario_IdSala",
                table: "SalaComentario",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdDocente",
                table: "Sala",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdResponsable",
                table: "Sala",
                column: "IdResponsable");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Docente_IdDocente",
                table: "Sala",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Responsable_IdResponsable",
                table: "Sala",
                column: "IdResponsable",
                principalTable: "Responsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaComentario_Sala_IdSala",
                table: "SalaComentario",
                column: "IdSala",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Docente_IdDocente",
                table: "Sala");

            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Responsable_IdResponsable",
                table: "Sala");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaComentario_Sala_IdSala",
                table: "SalaComentario");

            migrationBuilder.DropIndex(
                name: "IX_SalaComentario_IdSala",
                table: "SalaComentario");

            migrationBuilder.DropIndex(
                name: "IX_Sala_IdDocente",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Sala_IdResponsable",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "SalaComentario");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "IdDocente",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "IdResponsable",
                table: "Sala");
        }
    }
}
