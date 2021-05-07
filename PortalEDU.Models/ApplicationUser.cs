using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalEDU.Models
{
    public class ApplicationUser : IdentityUser
    {
        

        [Required(ErrorMessage = "El Codigo del Centro Escolar es obligatorio")]
        [MaxLength(5)]
        [Display(Name = "Codigo de su Centro Educativo")]
        public string CodigoCE { get; set; }
        public ICollection<Alumno> AlumnosIU { get; set; }

        //public ICollection<Docente> DocenteIU { get; set; } 

        public ICollection<Responsable> ResponsableIU { get; set; }

    }
}
