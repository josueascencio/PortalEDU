using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface IResponsableRepository:IRepository<Responsable>
    {
        IEnumerable<SelectListItem> GetListaResponsable();

        void Update(Responsable responsable);
    }
}
