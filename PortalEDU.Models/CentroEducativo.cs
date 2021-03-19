using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//#nullable disable

namespace PortalEDU.Models
{
    public class CentroEducativo
    {
        //public CentroEducativo()
        //{
        //    Aulas = new HashSet<Aula>();
        //    Docentes = new HashSet<Docente>();
        //}
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        public string Tipo { get; set; }
        [Required]
        public string Director { get; set; }

        [Display(Name = "Año Escolar")]
        [Required]
        public int IdAnioAcademico { get; set; }
        [Required]
                
        public DateTime update { get; set; }

        [ForeignKey("IdAnioAcademico")]
        public  Ciclo Ciclo { get; set; }
        //public virtual ICollection<Aula> Aulas { get; set; }
        //public virtual ICollection<Docente> Docentes { get; set; }
    }
}
