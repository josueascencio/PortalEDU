using Microsoft.AspNetCore.Mvc;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using PortalEDU.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEDU.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CentrosEducativosController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CentrosEducativosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }


        public IActionResult Index()
        {
            CentroEducativoVM centroEducativoVM = new CentroEducativoVM()
            {
                centroEducativo = new Models.CentroEducativo(),
                ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo()
            };

            return View(centroEducativoVM);
        }

        public IActionResult Create()
        {
            CentroEducativoVM centroEducativoVM = new CentroEducativoVM()
            {
                centroEducativo = new Models.CentroEducativo(),
                ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo()
            };

            return View(centroEducativoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CentroEducativoVM centroEducativoVM)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.CentroEducativo.Add(centroEducativoVM.centroEducativo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(centroEducativoVM);
        }




        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.CentroEducativo.GetAll(includeProperties: ("Ciclo")) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.CentroEducativo.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Centro Educativo" });
            }

            _contenedorTrabajo.CentroEducativo.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoría borrada Centro Educativo" });
        }
        #endregion

    }


}
