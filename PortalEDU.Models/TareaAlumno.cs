using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class TareaAlumno
    {
        public int Id { get; set; }
        public byte[] Documento { get; set; }
        public string Comnetario { get; set; }
        public int IdTareaDocente { get; set; }
        public int IdAlumno { get; set; }
        public byte[] Ts { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
        public virtual TareaDocente IdTareaDocenteNavigation { get; set; }
    }
}
