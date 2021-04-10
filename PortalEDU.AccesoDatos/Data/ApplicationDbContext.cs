using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace PortalEDU.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
             .SelectMany(t => t.GetForeignKeys())
             .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<AlumnoCurso> AlumnoCurso { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Calificaciones> Calificaciones { get; set; }
        public DbSet<CentroEducativo> CentroEducativo { get; set; }
        public DbSet<Ciclo> Ciclo { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<DocenteCurso> DocenteCurso { get; set; }
        //public DbSet<Padre> Padre { get; set; }
        public DbSet<Responsable> Responsable { get; set; }
        //public DbSet<Rol> Rol { get; set; }
        public DbSet<TareaAlumno> TareaAlumno { get; set; }
        public DbSet<TareaDocente> TareaDocente { get; set; }
        public DbSet<Sala> Sala { get; set; }
        //public DbSet<UsuarioSesion> UsuarioSesion { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");




        //    modelBuilder.Entity<AlumnoCurso>(entity =>
        //    {
        //        entity.HasKey(e => new { e.IdCurso, e.IdAlumno });

        //        //entity.ToTable("Alumno_Curso");

        //        //entity.Property(e => e.Ts)
        //        //    .IsRowVersion()
        //        //    .IsConcurrencyToken()
        //        //    .HasColumnName("ts");

        //        //entity.HasOne(d => d.IdAlumnoNavigation)
        //        //    .WithMany(p => p.AlumnoCursos)
        //        //    .HasForeignKey(d => d.IdAlumno)
        //        //    .OnDelete(DeleteBehavior.ClientSetNull)
        //        //    .HasConstraintName("FK_Alumno_Curso_Alumno");

        //        //entity.HasOne(d => d.IdCursoNavigation)
        //        //    .WithMany(p => p.AlumnoCursos)
        //        //    .HasForeignKey(d => d.IdCurso)
        //        //    .OnDelete(DeleteBehavior.ClientSetNull)
        //        //    .HasConstraintName("FK_Alumno_Curso_Curso");
        //    });


        //}
    }



}