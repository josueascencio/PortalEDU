using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface ICicloRepository:IRepository<Ciclo>
    {
        IEnumerable<SelectListItem> GetListaCiclo();

        void update(Ciclo ciclo);
    }
}
