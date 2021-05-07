using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalEDU.AccesoDatos.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoCE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciclo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnioAcademico = table.Column<int>(type: "int", nullable: false),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciclo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profesion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsable_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CentroEducativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAnioAcademico = table.Column<int>(type: "int", nullable: false),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroEducativo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroEducativo_Ciclo_IdAnioAcademico",
                        column: x => x.IdAnioAcademico,
                        principalTable: "Ciclo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCentroEducativo = table.Column<int>(type: "int", nullable: false),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aula_CentroEducativo_IdCentroEducativo",
                        column: x => x.IdCentroEducativo,
                        principalTable: "CentroEducativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradoAcademico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCentroEducativo = table.Column<int>(type: "int", nullable: false),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docente_CentroEducativo_IdCentroEducativo",
                        column: x => x.IdCentroEducativo,
                        principalTable: "CentroEducativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdAula = table.Column<int>(type: "int", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_Aula_IdAula",
                        column: x => x.IdAula,
                        principalTable: "Aula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDocente = table.Column<int>(type: "int", nullable: true),
                    IdResponsable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sala_Docente_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sala_Responsable_IdResponsable",
                        column: x => x.IdResponsable,
                        principalTable: "Responsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocenteCurso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCursoNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdDocenteNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteCurso", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Curso_IdCursoNavigationId",
                        column: x => x.IdCursoNavigationId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Docente_IdDocenteNavigationId",
                        column: x => x.IdDocenteNavigationId,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TareaDocente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDocente = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaDocente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TareaDocente_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TareaDocente_Docente_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalaComentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaComentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaComentario_Sala_IdSala",
                        column: x => x.IdSala,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoCurso",
                columns: table => new
                {
                    IdAlumnoCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    IdAlumno = table.Column<int>(type: "int", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoCurso", x => x.IdAlumnoCurso);
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerTrimestre = table.Column<decimal>(type: "decimal (18,4)", nullable: true),
                    SegundoTrimestre = table.Column<decimal>(type: "decimal (18,4)", nullable: true),
                    TercerTrimestre = table.Column<decimal>(type: "decimal (18,4)", nullable: true),
                    CuartoTrimestre = table.Column<decimal>(type: "decimal (18,4)", nullable: true),
                    Promedio = table.Column<decimal>(type: "decimal (18,4)", nullable: true),
                    IdAlumno = table.Column<int>(type: "int", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Carnet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCentroEducativo = table.Column<int>(type: "int", nullable: false),
                    update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdResponsable = table.Column<int>(type: "int", nullable: true),
                    IdCalificaciones = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumno_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumno_Calificaciones_IdCalificaciones",
                        column: x => x.IdCalificaciones,
                        principalTable: "Calificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumno_CentroEducativo_IdCentroEducativo",
                        column: x => x.IdCentroEducativo,
                        principalTable: "CentroEducativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumno_Responsable_IdResponsable",
                        column: x => x.IdResponsable,
                        principalTable: "Responsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TareaAlumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comnetario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTareaDocente = table.Column<int>(type: "int", nullable: false),
                    IdAlumno = table.Column<int>(type: "int", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaAlumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TareaAlumno_Alumno_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TareaAlumno_TareaDocente_IdTareaDocente",
                        column: x => x.IdTareaDocente,
                        principalTable: "TareaDocente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdCalificaciones",
                table: "Alumno",
                column: "IdCalificaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdCentroEducativo",
                table: "Alumno",
                column: "IdCentroEducativo");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdResponsable",
                table: "Alumno",
                column: "IdResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_IdUsuario",
                table: "Alumno",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_IdAlumno",
                table: "AlumnoCurso",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_IdCurso",
                table: "AlumnoCurso",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Aula_IdCentroEducativo",
                table: "Aula",
                column: "IdCentroEducativo");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdAlumno",
                table: "Calificaciones",
                column: "IdAlumno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CentroEducativo_IdAnioAcademico",
                table: "CentroEducativo",
                column: "IdAnioAcademico");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdAula",
                table: "Curso",
                column: "IdAula");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_IdCentroEducativo",
                table: "Docente",
                column: "IdCentroEducativo");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_IdCursoNavigationId",
                table: "DocenteCurso",
                column: "IdCursoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_IdDocenteNavigationId",
                table: "DocenteCurso",
                column: "IdDocenteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsable_IdUsuario",
                table: "Responsable",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdDocente",
                table: "Sala",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdResponsable",
                table: "Sala",
                column: "IdResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_SalaComentario_IdSala",
                table: "SalaComentario",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_TareaAlumno_IdAlumno",
                table: "TareaAlumno",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_TareaAlumno_IdTareaDocente",
                table: "TareaAlumno",
                column: "IdTareaDocente");

            migrationBuilder.CreateIndex(
                name: "IX_TareaDocente_IdCurso",
                table: "TareaDocente",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_TareaDocente_IdDocente",
                table: "TareaDocente",
                column: "IdDocente");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoCurso_Alumno_IdAlumno",
                table: "AlumnoCurso",
                column: "IdAlumno",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Alumno_AspNetUsers_IdUsuario",
                table: "Alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_AspNetUsers_IdUsuario",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Calificaciones_IdCalificaciones",
                table: "Alumno");

            migrationBuilder.DropTable(
                name: "AlumnoCurso");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DocenteCurso");

            migrationBuilder.DropTable(
                name: "SalaComentario");

            migrationBuilder.DropTable(
                name: "TareaAlumno");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "TareaDocente");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Aula");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "CentroEducativo");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropTable(
                name: "Ciclo");
        }
    }
}
