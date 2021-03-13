using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Calificacione
    {
        public int Id { get; set; }
        public decimal PrimerTrimestre { get; set; }
        public decimal SegundoTrimestre { get; set; }
        public decimal TercerTrimestre { get; set; }
        public decimal CuartoTrimestre { get; set; }
        public decimal Promedio { get; set; }
        public int IdAlumno { get; set; }
        public byte[] Ts { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
    }
}
