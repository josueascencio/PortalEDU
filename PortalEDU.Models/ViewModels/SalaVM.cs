using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.Models.ViewModels
{
    public class SalaVM
    {
        public IEnumerable<Sala> IESala { get; set; }
        public List<Sala> ListSala { get; set; }
        public Sala SalaEnVM { get; set; }

        public IEnumerable<SalaComentario> IESalaComentario { get; set; }
        public List<SalaComentario> ListSalaComentario { get; set; }
        public SalaComentario SalaComentarioEnVM { get; set; }


        public List<Docente> ListaDocente { get; set; }
        public IEnumerable<SelectListItem> ListaDocenteItem { get; set; }
        public List<Responsable> ListaResponsable { get; set; }

        public IEnumerable<SelectListItem> ListaResponsableItems { get; set; }



    }
}
