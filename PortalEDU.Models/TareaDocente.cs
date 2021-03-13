using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class TareaDocente
    {
        public TareaDocente()
        {
            TareaAlumnos = new HashSet<TareaAlumno>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public byte[] Documento { get; set; }
        public int? Puntuacion { get; set; }
        public string Comentario { get; set; }
        public int? IdDocente { get; set; }
        public byte[] Ts { get; set; }

        public virtual Docente IdDocenteNavigation { get; set; }
        public virtual ICollection<TareaAlumno> TareaAlumnos { get; set; }
    }
}
