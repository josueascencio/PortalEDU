using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface IAulaRepository:IRepository<Aula>
    {
        IEnumerable<SelectListItem> GetListaAula();

        void update(Aula aula);
    }
}
