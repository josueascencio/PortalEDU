using Microsoft.AspNetCore.Mvc;
using PortalEDU.AccesoDatos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEDU.WEB.Areas.Admin
{
    [Area("Admin")]
    public class CiclosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CiclosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }


        #region LLAMADAS A LAS API
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Ciclo.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var ObjFromDb = _contenedorTrabajo.Ciclo.Get(id);

            if (ObjFromDb == null)
            {
                return Json(new { success = false, message = "Error al intentar borrar categoria" });

            }

            _contenedorTrabajo.Ciclo.Remove(ObjFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoria borrada con exito" });
        }

        #endregion
    }
}
