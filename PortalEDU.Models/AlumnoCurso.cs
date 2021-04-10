using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    public partial class AlumnoCurso
    {

        [Key]
        public int IdAlumnoCurso { get; set; }
        public int IdCurso { get; set; }
        public int IdAlumno { get; set; }
        [Required]
        public DateTime Update { get; set; }
        [ForeignKey("IdAlumno")]
        public virtual Alumno Alumno { get; set; }
        [ForeignKey("IdCurso")]
        public virtual Curso Curso { get; set; }
    }
}


