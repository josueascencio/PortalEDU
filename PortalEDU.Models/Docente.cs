using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    public class Docente
    {
        //public Docente()
        //{
        //    DocenteCursos = new HashSet<DocenteCurso>();
        //    TareaDocentes = new HashSet<TareaDocente>();
        //}
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime FechaNacimiento { get; set; }
        public string GradoAcademico { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public string Sexo { get; set; }

        [Display(Name = "Centro Educativo")]
        public int IdCentroEducativo { get; set; }
        [Required]
        public DateTime update { get; set; }

        [ForeignKey("IdCentroEducativo")]
        public CentroEducativo CentroEducativo { get; set; }


        
        //public virtual ICollection<DocenteCurso> DocenteCursos { get; set; }
        //public virtual ICollection<TareaDocente> TareaDocentes { get; set; }
    }
}
