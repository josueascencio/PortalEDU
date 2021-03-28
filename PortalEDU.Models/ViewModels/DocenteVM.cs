using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace PortalEDU.Models.ViewModels
{
    public class DocenteVM
    {
        public Docente docente { get; set; }

        public IEnumerable<SelectListItem>ListaCentroEducativo { get; set; }

        

        

    }
}
