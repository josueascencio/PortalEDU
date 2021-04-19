using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICicloRepository Ciclo { get; }
        ICentroEducativoRepository CentroEducativo { get; }
        IAulaRepository Aula { get; }
        IAlumnoRepository Alumno { get; }
        IDocenteRepository Docente { get; }
        IResponsableRepository Responsable { get; }
        ICursoRepository Curso { get; }
        ICalificacionesRepository Calificaciones { get; }
        ITareaDocenteRepository TareaDocente { get; }



        void Save();
    }
}
