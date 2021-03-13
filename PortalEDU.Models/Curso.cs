using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Curso
    {
        public Curso()
        {
            AlumnoCursos = new HashSet<AlumnoCurso>();
            DocenteCursos = new HashSet<DocenteCurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string Aviso { get; set; }
        public byte[] Imagen { get; set; }
        public bool Estado { get; set; }
        public int IdAula { get; set; }
        public byte[] Ts { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual ICollection<AlumnoCurso> AlumnoCursos { get; set; }
        public virtual ICollection<DocenteCurso> DocenteCursos { get; set; }
    }
}
