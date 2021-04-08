using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    public partial class TareaAlumno
    {
        [Key]
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Comnetario { get; set; }
        public int IdTareaDocente { get; set; }
        public int IdAlumno { get; set; }
        [Required]
        public DateTime Update { get; set; }
        [ForeignKey("IdAlumno")]
        public virtual Alumno Alumno { get; set; }
        [ForeignKey("IdTareaDocente")]
        public virtual TareaDocente TareDocente { get; set; }
    }
}
