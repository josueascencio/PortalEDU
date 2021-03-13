using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class ResponsableAlumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Profesion { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public string TelefonoTrabajo { get; set; }
        public int IdAlumno { get; set; }
        public byte[] Ts { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
    }
}
