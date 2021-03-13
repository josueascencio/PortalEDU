using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public  DbSet<Alumno> Alumno { get; set; }
        public  DbSet<AlumnoCurso> AlumnoCurso { get; set; }
        public  DbSet<Aula> Aula { get; set; }
        public  DbSet<Calificacione> Calificacione { get; set; }
        public  DbSet<CentroEducativo> CentroEducativo { get; set; }
        public  DbSet<Ciclo> Ciclo { get; set; }
        public  DbSet<Curso> Curso { get; set; }
        public  DbSet<Docente> Docente { get; set; }
        public  DbSet<DocenteCurso> DocenteCurso { get; set; }
        public  DbSet<Padre> Padre { get; set; }
        public  DbSet<ResponsableAlumno> ResponsableAlumno { get; set; }
        public  DbSet<Rol> Rol { get; set; }
        public  DbSet<TareaAlumno> TareaAlumno { get; set; }
        public  DbSet<TareaDocente> TareaDocente { get; set; }
        public  DbSet<UsuarioSesion> UsuarioSesion { get; set; }
    }
}
