using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface ITareaDocenteRepository:IRepository<TareaDocente>
    {
        IEnumerable<SelectListItem> GetListaTareaDocente();

        void Update(TareaDocente tareaDocente);
    }
}
