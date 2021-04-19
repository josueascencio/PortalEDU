using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.Models.ViewModels
{
    public class TareaDocenteVM
    {
        public Alumno alumno { get; set; }
        public List<Alumno> alumnos { get; set; }

        public TareaDocente TareaDocente { get; set; }
        public List<TareaDocente> TareaDocenteList { get; set; }

        public Docente Docente { get; set; }
        public List<Docente> DocenteList { get; set; }

        public Curso Curso { get; set; }
        public List<Curso> CursoList { get; set; }


        public IEnumerable<Alumno> ListaAlumnos { get; set; }
        public IEnumerable<SelectListItem> ListaAlumnosItem { get; set; }
        public IEnumerable<Calificaciones> ListaCalificaciones { get; set; }
    }
}
