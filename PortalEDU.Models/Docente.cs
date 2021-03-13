using System;
using System.Collections.Generic;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Docente
    {
        public Docente()
        {
            DocenteCursos = new HashSet<DocenteCurso>();
            TareaDocentes = new HashSet<TareaDocente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaNacimeinto { get; set; }
        public string GradoAcademico { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public string Sexo { get; set; }
        public int IdCentroEducativo { get; set; }
        public byte[] Ts { get; set; }

        public virtual CentroEducativo IdCentroEducativoNavigation { get; set; }
        public virtual ICollection<DocenteCurso> DocenteCursos { get; set; }
        public virtual ICollection<TareaDocente> TareaDocentes { get; set; }
    }
}
