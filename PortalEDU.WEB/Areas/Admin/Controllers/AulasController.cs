using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEDU.WEB.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AulasController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public AulasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }


        public IActionResult Index()
        {
            AulaVM centroEducativoVM = new AulaVM()
            {
                aula = new Models.Aula(),
                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo()
            };

            return View(centroEducativoVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AulaVM aulaVM = new AulaVM()
            {
                aula = new Models.Aula(),
                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo()
            };

            return View(aulaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AulaVM aulaVM)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Aula.Add(aulaVM.aula);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            aulaVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            return View(aulaVM);
        }



        public IActionResult CardAulas() {


            return View();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            AulaVM aulaVM = new AulaVM();
            aulaVM.aula = _contenedorTrabajo.Aula.Get(id);

            if (aulaVM == null)
            {
                return NotFound();

            }
            aulaVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            return View(aulaVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AulaVM aulaVM)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Aula.update(aulaVM.aula);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(aulaVM);
        }



        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Aula.GetAll(includeProperties: ("CentroEducativo")) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Aula.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Aula" });
            }

            _contenedorTrabajo.Aula.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Aula borrada con exito" });
        }
        #endregion

    }


}
