using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface ICalificacionesRepository:IRepository<Calificaciones>
    {
        IEnumerable<SelectListItem> GetListaCalificaciones();

        void Update(Calificaciones calificaciones);
    }
}
