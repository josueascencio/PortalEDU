//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//#nullable disable

//namespace PortalEDU.Models
//{
//    public partial class PortalEDU5Context : DbContext
//    {
//        public PortalEDU5Context()
//        {
//        }

//        public PortalEDU5Context(DbContextOptions<PortalEDU5Context> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Alumno> Alumnos { get; set; }
//        public virtual DbSet<AlumnoCurso> AlumnoCursos { get; set; }
//        public virtual DbSet<Aula> Aulas { get; set; }
//        public virtual DbSet<Calificaciones> Calificaciones { get; set; }
//        public virtual DbSet<CentroEducativo> CentroEducativos { get; set; }
//        public virtual DbSet<Ciclo> Ciclos { get; set; }
//        public virtual DbSet<Curso> Cursos { get; set; }
//        public virtual DbSet<Docente> Docentes { get; set; }
//        public virtual DbSet<DocenteCurso> DocenteCursos { get; set; }
//        public virtual DbSet<Padre> Padres { get; set; }
//        public virtual DbSet<ResponsableAlumno> ResponsableAlumnos { get; set; }
//        public virtual DbSet<Rol> Rols { get; set; }
//        public virtual DbSet<TareaAlumno> TareaAlumnos { get; set; }
//        public virtual DbSet<TareaDocente> TareaDocentes { get; set; }
//        public virtual DbSet<UsuarioSesion> UsuarioSesions { get; set; }

////        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////        {
////            if (!optionsBuilder.IsConfigured)
////            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
////                optionsBuilder.UseSqlServer("Server=localhost;Database=PortalEDU5; user id= sa; password=Ef1c13nc1@;");
////            }
////        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

//            modelBuilder.Entity<Alumno>(entity =>
//            {
//                entity.ToTable("Alumno");

//                entity.Property(e => e.Apellido)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Carnet)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Direccion)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

//                entity.Property(e => e.Foto).HasColumnType("image");

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Sexo)
//                    .HasMaxLength(10)
//                    .IsUnicode(false)
//                    .IsFixedLength(true);

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();
//            });

//            modelBuilder.Entity<AlumnoCurso>(entity =>
//            {
//                entity.HasKey(e => new { e.IdCurso, e.IdAlumno });

//                entity.ToTable("Alumno_Curso");

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken()
//                    .HasColumnName("ts");

//                entity.HasOne(d => d.IdAlumnoNavigation)
//                    .WithMany(p => p.AlumnoCursos)
//                    .HasForeignKey(d => d.IdAlumno)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Alumno_Curso_Alumno");

//                entity.HasOne(d => d.IdCursoNavigation)
//                    .WithMany(p => p.AlumnoCursos)
//                    .HasForeignKey(d => d.IdCurso)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Alumno_Curso_Curso");
//            });

//            modelBuilder.Entity<Aula>(entity =>
//            {
//                entity.ToTable("Aula");

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Seccion)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdCentroEducativoNavigation)
//                    .WithMany(p => p.Aulas)
//                    .HasForeignKey(d => d.IdCentroEducativo)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Aula_Centro_Educativo");
//            });

//            modelBuilder.Entity<Calificacione>(entity =>
//            {
//                entity.Property(e => e.CuartoTrimestre).HasColumnType("decimal(18, 0)");

//                entity.Property(e => e.PrimerTrimestre).HasColumnType("decimal(18, 0)");

//                entity.Property(e => e.Promedio).HasColumnType("decimal(18, 0)");

//                entity.Property(e => e.SegundoTrimestre).HasColumnType("decimal(18, 0)");

//                entity.Property(e => e.TercerTrimestre).HasColumnType("decimal(18, 0)");

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdAlumnoNavigation)
//                    .WithMany(p => p.Calificaciones)
//                    .HasForeignKey(d => d.IdAlumno)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Calificaciones_Alumno");
//            });

//            modelBuilder.Entity<CentroEducativo>(entity =>
//            {
//                entity.ToTable("Centro_Educativo");

//                entity.Property(e => e.Correo)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Direccion)
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.Property(e => e.Director)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Telefono)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Tipo)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdAnioAcademicoNavigation)
//                    .WithMany(p => p.CentroEducativos)
//                    .HasForeignKey(d => d.IdAnioAcademico)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Centro_Educativo_Ciclo");
//            });

//            modelBuilder.Entity<Ciclo>(entity =>
//            {
//                entity.ToTable("Ciclo");

//                entity.Property(e => e.AnioAcademico).HasColumnName("Anio_Academico");

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();
//            });

//            modelBuilder.Entity<Curso>(entity =>
//            {
//                entity.ToTable("Curso");

//                entity.Property(e => e.Aviso)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Descripcion)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FechaFinal).HasColumnType("date");

//                entity.Property(e => e.FechaInicio).HasColumnType("date");

//                entity.Property(e => e.Imagen).HasColumnType("image");

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Ts)
//                    .IsRequired()
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdAulaNavigation)
//                    .WithMany(p => p.Cursos)
//                    .HasForeignKey(d => d.IdAula)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Curso_Aula");
//            });

//            modelBuilder.Entity<Docente>(entity =>
//            {
//                entity.ToTable("Docente");

//                entity.Property(e => e.Apellido)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Direccion)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

//                entity.Property(e => e.Foto).HasColumnType("image");

//                entity.Property(e => e.GradoAcademico)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Sexo)
//                    .HasMaxLength(10)
//                    .IsUnicode(false)
//                    .IsFixedLength(true);

//                entity.Property(e => e.Telefono)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdCentroEducativoNavigation)
//                    .WithMany(p => p.Docentes)
//                    .HasForeignKey(d => d.IdCentroEducativo)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Docente_Centro_Educativo");
//            });

//            modelBuilder.Entity<DocenteCurso>(entity =>
//            {
//                entity.HasKey(e => new { e.IdCurso, e.IdDocente });

//                entity.ToTable("Docente_Curso");

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdCursoNavigation)
//                    .WithMany(p => p.DocenteCursos)
//                    .HasForeignKey(d => d.IdCurso)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Docente_Curso_Curso");

//                entity.HasOne(d => d.IdDocenteNavigation)
//                    .WithMany(p => p.DocenteCursos)
//                    .HasForeignKey(d => d.IdDocente)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Docente_Curso_Docente");
//            });

//            modelBuilder.Entity<Padre>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("Padre");

//                entity.Property(e => e.Id).HasColumnName("id");
//            });

//            modelBuilder.Entity<ResponsableAlumno>(entity =>
//            {
//                entity.ToTable("Responsable_Alumno");

//                entity.Property(e => e.Apellido)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Direccion)
//                    .HasMaxLength(10)
//                    .IsFixedLength(true);

//                entity.Property(e => e.Foto).HasColumnType("image");

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Profesion)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Telefono)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.TelefonoTrabajo)
//                    .HasMaxLength(10)
//                    .IsFixedLength(true);

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdAlumnoNavigation)
//                    .WithMany(p => p.ResponsableAlumnos)
//                    .HasForeignKey(d => d.IdAlumno)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Responsable_Alumno_Alumno");
//            });

//            modelBuilder.Entity<Rol>(entity =>
//            {
//                entity.HasKey(e => e.IdRol);

//                entity.ToTable("Rol");

//                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

//                entity.Property(e => e.Descripcion)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<TareaAlumno>(entity =>
//            {
//                entity.ToTable("Tarea_Alumno");

//                entity.Property(e => e.Comnetario)
//                    .HasMaxLength(200)
//                    .IsUnicode(false);

//                entity.Property(e => e.Documento).HasMaxLength(50);

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdAlumnoNavigation)
//                    .WithMany(p => p.TareaAlumnos)
//                    .HasForeignKey(d => d.IdAlumno)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Tarea_Alumno_Alumno");

//                entity.HasOne(d => d.IdTareaDocenteNavigation)
//                    .WithMany(p => p.TareaAlumnos)
//                    .HasForeignKey(d => d.IdTareaDocente)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Tarea_Alumno_Tarea_Docente");
//            });

//            modelBuilder.Entity<TareaDocente>(entity =>
//            {
//                entity.ToTable("Tarea_Docente");

//                entity.Property(e => e.Comentario)
//                    .HasMaxLength(200)
//                    .IsUnicode(false);

//                entity.Property(e => e.Descripcion)
//                    .HasMaxLength(200)
//                    .IsUnicode(false);

//                entity.Property(e => e.Documento).HasMaxLength(50);

//                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

//                entity.Property(e => e.FechaFinalizacion).HasColumnType("datetime");

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Ts)
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.IdDocenteNavigation)
//                    .WithMany(p => p.TareaDocentes)
//                    .HasForeignKey(d => d.IdDocente)
//                    .HasConstraintName("FK_Tarea_Docente_Docente");
//            });

//            modelBuilder.Entity<UsuarioSesion>(entity =>
//            {
//                entity.HasKey(e => e.IdUsuario)
//                    .HasName("PK_Usuario");

//                entity.ToTable("Usuario_Sesion");

//                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

//                entity.Property(e => e.Correo)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Password).IsUnicode(false);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
