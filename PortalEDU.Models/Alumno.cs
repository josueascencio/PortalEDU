using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            AlumnoCursos = new HashSet<AlumnoCurso>();
            Calificaciones = new HashSet<Calificacione>();
            ResponsableAlumnos = new HashSet<ResponsableAlumno>();
            TareaAlumnos = new HashSet<TareaAlumno>();
        }

        public int Id { get; set; }
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public string Sexo { get; set; }
        public byte[] Ts { get; set; }

        public virtual ICollection<AlumnoCurso> AlumnoCursos { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<ResponsableAlumno> ResponsableAlumnos { get; set; }
        public virtual ICollection<TareaAlumno> TareaAlumnos { get; set; }
    }
}
