using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Curso
    {
        public Curso()
        {
            AlumnoCursos = new HashSet<AlumnoCurso>();
            DocenteCursos = new HashSet<DocenteCurso>();
        }

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string Aviso { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
        public int IdAula { get; set; }
        [Required]
        public DateTime update { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual ICollection<AlumnoCurso> AlumnoCursos { get; set; }
        public virtual ICollection<DocenteCurso> DocenteCursos { get; set; }
    }
}
