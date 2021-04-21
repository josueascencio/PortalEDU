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

        public Docente DocenteVM { get; set; }
        public List<Docente> DocenteList { get; set; }

        public Curso CursoVM { get; set; }
        public List<Curso> CursoList { get; set; }


        public Aula AulaVM { get; set; }
        public List<Aula> AulaList { get; set; }


        public TareaAlumno TareaAlumnoVM { get; set; }
        public List<Aula> TareaAlumnoList { get; set; }


        public IEnumerable<Alumno> ListaAlumnos { get; set; }
        public IEnumerable<TareaAlumno> ListaTareaAlumno { get; set; }
        public IEnumerable<SelectListItem> ListaAlumnosItem { get; set; }
        public IEnumerable<SelectListItem> ListaCursoItem { get; set; }
        public IEnumerable<SelectListItem> ListaDocenteItem { get; set; }
        public IEnumerable<SelectListItem> ListaTareaDocenteItem { get; set; }
        public IEnumerable<SelectListItem> ListaTareaAlumnoItem { get; set; }
    }
}
