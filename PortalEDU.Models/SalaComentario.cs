using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PortalEDU.Models
{
    public class SalaComentario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

        public string Contenido { get; set; }

        public DateTime FechaPublicacion { get; set; }
        [Display(Name = "Seleccione la Sala")]
        public int IdSala { get; set; }
        [ForeignKey("IdSala")]
        public Sala Sala { get; set; }


    }
}
