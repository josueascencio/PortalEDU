using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace PortalEDU.Models.ViewModels
{
    public class ResponsableVM
    {
        public Responsable responsable { get; set; }

        public IEnumerable<SelectListItem>ListaAlumnos { get; set; }

        public IEnumerable<Alumno> alumno { get; set; }

    }
}
