using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PortalEDU.Models
{
    public class Sala 
    {
        [Key]
        public int Id { get; set; }
        
        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public string Autor { get; set; }

        public int? IdDocente { get; set; }

        public int? IdResponsable { get; set; }

        public ICollection<SalaComentario> SalaComentarios { get; set; }
        
        [ForeignKey("IdDocente")]
        public Docente Docente { get; set; }

        [ForeignKey("IdResponsable")]
        public Responsable Responsable { get; set; }

    }
}
