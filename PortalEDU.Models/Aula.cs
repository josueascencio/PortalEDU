using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    public class Aula
    {
        //public Aula()
        //{
        //    Cursos = new HashSet<Curso>();
        //}
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Seccion { get; set; }
       
        [Display(Name = "Centro Educativo")]
        [Required]
        public int IdCentroEducativo { get; set; }
        
        
        [Required]
        public DateTime update { get; set; }


        [ForeignKey("IdCentroEducativo")]
        public CentroEducativo CentroEducativo { get; set; }

        //public virtual CentroEducativo IdCentroEducativoNavigation { get; set; }
        //public virtual ICollection<Curso> Cursos { get; set; }
    }
}
