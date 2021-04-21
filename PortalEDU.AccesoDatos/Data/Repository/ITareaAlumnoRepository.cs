using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface ITareaAlumnoRepository : IRepository<TareaAlumno>
    {
        IEnumerable<SelectListItem> GetListaTareaAlumno();

        void Update(TareaAlumno tareaAlumno);
    }
}
