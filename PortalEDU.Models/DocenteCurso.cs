using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalEDU.Models
{
    public partial class DocenteCurso
    {
        [Key]
        public int IdCurso { get; set; }
        public int IdDocente { get; set; }
        public byte[] Ts { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Docente IdDocenteNavigation { get; set; }
    }
}
