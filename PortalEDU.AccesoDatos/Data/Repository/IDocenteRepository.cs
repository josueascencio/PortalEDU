using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface IDocenteRepository:IRepository<Docente>
    {
        IEnumerable<SelectListItem> GetListaDocente();

        void Update(Docente docente);
    }
}
