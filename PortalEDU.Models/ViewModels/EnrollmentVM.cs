using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.Models.ViewModels
{
    public class EnrollmentVM
    {
        public AlumnoCurso AlumnoCursoVM { get; set; }

        public Curso CursoVM { get; set; }

        public Alumno AlumnoVM { get; set; }


        public ICollection<AlumnoCurso> AlumnoCursoVMList { get; set; }

        public ICollection<Curso> CursoVMList { get; set; }

        public ICollection<Alumno> AlumnoVMList { get; set; }
    }
}
