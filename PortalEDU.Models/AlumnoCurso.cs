using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalEDU.Models
{
    public partial class AlumnoCurso
    {
        [Key]
        public int IdCurso { get; set; }
        public int IdAlumno { get; set; }
        [Required]
        public DateTime update { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
    }
}
