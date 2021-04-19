using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace PortalEDU.Models.ViewModels
{
    public class AlumnoVM
    {
        public Alumno alumno { get; set; }
        public List<Alumno> alumnos { get; set; }

        public IEnumerable<SelectListItem> ListaCentroEducativo { get; set; }
        public IEnumerable<SelectListItem> ListaResponsable { get; set; }


        public Calificaciones calificaciones { get; set; }
        public List<Calificaciones> calificacionesList { get; set; }
        public IEnumerable<Calificaciones> ListaCalificaciones { get; set; }
    }
}