using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface ICursoRepository:IRepository<Curso>
    {
        IEnumerable<SelectListItem> GetListaCurso();

        void Update(Curso curso);
    }
}
