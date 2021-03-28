using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface IAlumnoRepository:IRepository<Alumno>
    {
        IEnumerable<SelectListItem> GetListaAlumno();

        void update(Alumno alumno);
    }
}
