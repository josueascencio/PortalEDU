using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //public string IdAutor { get; set; }

        //public User Author { get; set; }

        
    }
}
