using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Alumno
    {
        //public Alumno()
        //{
        //    AlumnoCursos = new HashSet<AlumnoCurso>();
        //    Calificaciones = new HashSet<Calificacione>();
        //    ResponsableAlumnos = new HashSet<ResponsableAlumno>();
        //    TareaAlumnos = new HashSet<TareaAlumno>();
        //}
        [Key]
        public int Id { get; set; }
        [Required]
        public string Carnet { get; set; }
      
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Direccion { get; set; }
        
        public string Foto { get; set; }
        public string Sexo { get; set; }

        [Display (Name ="Centro Educativo")]
        public int IdCentroEducativo { get; set; }

        [Required]
        public DateTime? update { get; set; }


        [ForeignKey("IdCentroEducativo")]
        public CentroEducativo CentroEducativo {get; set;}


        [Display(Name = "Responsable Asignado")]
        public int? IdResponsable{ get; set; }

        
        [ForeignKey("IdResponsable")]
        public virtual Responsable Responsable { get; set; }
        //public virtual ICollection<AlumnoCurso> AlumnoCursos { get; set; }
        //public virtual ICollection<Calificacione> Calificaciones { get; set; }
        //public virtual ICollection<ResponsableAlumno> ResponsableAlumnos { get; set; }
        //public virtual ICollection<TareaAlumno> TareaAlumnos { get; set; }
    }
}
