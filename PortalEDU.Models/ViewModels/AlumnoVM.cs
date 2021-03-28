using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace PortalEDU.Models.ViewModels
{
    public class AlumnoVM
    {
        public Alumno alumno { get; set; }

        public IEnumerable<SelectListItem> ListaCentroEducativo { get; set; }
        public IEnumerable<SelectListItem> ListaResponsable { get; set; }
    }
}