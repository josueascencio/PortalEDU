using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalEDU.Models
{
    public partial class TareaAlumno
    {
        [Key]
        public int Id { get; set; }
        public byte[] Documento { get; set; }
        public string Comnetario { get; set; }
        public int IdTareaDocente { get; set; }
        public int IdAlumno { get; set; }
        [Required]
        public DateTime update { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
        public virtual TareaDocente IdTareaDocenteNavigation { get; set; }
    }
}
