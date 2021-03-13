using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface ICentroEducativoRepository:IRepository<CentroEducativo>
    {
        //IEnumerable<SelectListItem> GetListaCentroEducativo();

        void update(CentroEducativo centroEducativo);
    }
}
