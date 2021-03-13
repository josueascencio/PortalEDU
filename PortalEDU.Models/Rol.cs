using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
