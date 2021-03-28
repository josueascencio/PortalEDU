using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalEDU.Models
{
    public class Responsable
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Profesion { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public string TelefonoTrabajo { get; set; }
        //public int IdAlumno { get; set; }
        [Required]
        public DateTime update { get; set; }


        [Required]
        [Display(Name = "Alumnos a Cargo")]
     
        public virtual ICollection<Alumno> AlumnoLista { get; set; }

        //public virtual Alumno IdAlumnoNavigation { get; set; }
    }
}
