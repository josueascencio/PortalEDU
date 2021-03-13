using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Aula
    {
        public Aula()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Seccion { get; set; }
        public int IdCentroEducativo { get; set; }
        public byte[] Ts { get; set; }

        public virtual CentroEducativo IdCentroEducativoNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
