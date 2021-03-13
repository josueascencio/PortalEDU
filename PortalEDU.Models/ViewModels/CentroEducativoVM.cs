using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.Models.ViewModels
{
    public class CentroEducativoVM
    {
        public CentroEducativo centroEducativo { get; set; }

        public IEnumerable<SelectListItem>ListaCiclo { get; set; }

    }
}
