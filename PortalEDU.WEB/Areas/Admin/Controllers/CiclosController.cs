using Microsoft.AspNetCore.Mvc;
using PortalEDU.AccesoDatos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEDU.WEB.Areas.Admin.Controllers
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
            //CentroEducativoVM centroEducativoVM = new CentroEducativoVM()
            //{
            //    centroEducativo = new Models.CentroEducativo(),
            //    ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo()
            //};

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            //CentroEducativoVM centroEducativoVM = new CentroEducativoVM()
            //{
            //    centroEducativo = new Models.CentroEducativo(),
            //    ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo()
            //};

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(CentroEducativoVM centroEducativoVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _contenedorTrabajo.CentroEducativo.Add(centroEducativoVM.centroEducativo);
        //        _contenedorTrabajo.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    centroEducativoVM.ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo();
        //    return View(centroEducativoVM);
        //}




        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    CentroEducativoVM centroEducativoVM = new CentroEducativoVM();
        //    centroEducativoVM.centroEducativo = _contenedorTrabajo.CentroEducativo.Get(id);

        //    if (centroEducativoVM == null)
        //    {
        //        return NotFound();

        //    }
        //    centroEducativoVM.ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo();
        //    return View(centroEducativoVM);
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(CentroEducativo centroEducativo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _contenedorTrabajo.CentroEducativo.update(centroEducativo);
        //        _contenedorTrabajo.Save();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(centroEducativo);
        //}



        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Ciclo.GetAll()});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Ciclo.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Ciclo academico" });
            }

            _contenedorTrabajo.Ciclo.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Ciclo academico borrado con exito" });
        }
        #endregion

    }


}
