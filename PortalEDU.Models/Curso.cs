using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PortalEDU.Utilidades;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Curso
    {
        //public Curso()
        //{
        //    AlumnoCursos = new HashSet<AlumnoCurso>();
        //    DocenteCursos = new HashSet<DocenteCurso>();
        //}

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? FechaFinal { get; set; }
        //public string Aviso { get; set; }
        //public string Imagen { get; set; }
        [Display(Name = "Activar / Desactivar")]
        public bool Estado { get; set; }
        public int IdAula { get; set; }
        [Required]
        public DateTime Update { get; set; }


        //[NotMapped]
        //public int Duration
        //    => this.FechaInicio.DaysTo(this.FechaFinal);



        [ForeignKey("IdAula")]
        public virtual Aula Aula { get; set; }
        public virtual ICollection<AlumnoCurso> AlumnoCursos { get; set; }
        public virtual ICollection<DocenteCurso> DocenteCursos { get; set; } = new List<DocenteCurso>();
        public virtual ICollection<TareaDocente> TareaDocente { get; set; }
    }
}
