using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEDU.AccesoDatos.Data;
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
    public class CalificacionesController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;

        public CalificacionesController(IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
        }


        public IActionResult Index()
        {
            CalificacionesVM centroEducativoVM = new CalificacionesVM()
            {
                calificaciones = new Models.Calificaciones(),
                ListaAlumnosItem = _contenedorTrabajo.Alumno.GetListaAlumno(),
            };

            return View(centroEducativoVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CalificacionesVM calificacionesVM = new CalificacionesVM()
            {
                calificaciones = new Models.Calificaciones(),
                ListaAlumnosItem = _contenedorTrabajo.Alumno.GetListaAlumno(),
                alumnos = _contenedorTrabajo.Alumno.GetAll().ToList(),
                
            };
            

            return View(calificacionesVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CalificacionesVM calificacionesVM)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var prome = 4;

                    calificacionesVM.calificaciones.Promedio = (calificacionesVM.calificaciones.PrimerTrimestre +
                        calificacionesVM.calificaciones.SegundoTrimestre +
                        calificacionesVM.calificaciones.TercerTrimestre +
                        calificacionesVM.calificaciones.CuartoTrimestre) / prome;
                    _contenedorTrabajo.Calificaciones.Add(calificacionesVM.calificaciones);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (DbUpdateException )
            {

                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Este alumno ya se ecnuetra registrado por favor elija otro carnet.");
            }

            //calificacionesVM.ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo();
            calificacionesVM.alumnos = _contenedorTrabajo.Alumno.GetAll().ToList();
            return View(calificacionesVM);
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            CalificacionesVM calificacionesVM = new CalificacionesVM();

            calificacionesVM.calificaciones  = _contenedorTrabajo.Calificaciones.Get(id);

            if (calificacionesVM == null)
            {
                return NotFound();

            }
            calificacionesVM.alumnos = _contenedorTrabajo.Alumno.GetAll().ToList();
            return View(calificacionesVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Calificaciones.Update(calificaciones);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(calificaciones);
        }



        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Calificaciones.GetAll(includeProperties: ("Alumno")) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Calificaciones.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Calificacion" });
            }

            _contenedorTrabajo.Calificaciones.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Calificacion borrada con exito" });
        }
        #endregion

    }


}
