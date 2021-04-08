using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    public partial class TareaDocente
    {
        //public TareaDocente()
        //{
        //    TareaAlumnos = new HashSet<TareaAlumno>();
        //}

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaFinalizacion { get; set; }
        public string Documento { get; set; }
        public int? Puntuacion { get; set; }
        public string Comentario { get; set; }
        public int? IdDocente { get; set; }
        public bool Estado { get; set; }
        [Required]
        public DateTime Update { get; set; }
        public int? IdCurso { get; set; }

        [ForeignKey("IdDocente")]
        public virtual Docente Docente { get; set; }
        [ForeignKey("IdCurso")]
        public virtual Curso Curso { get; set; }
        public virtual ICollection<TareaAlumno> TareaAlumnos { get; set; }
    }
}
