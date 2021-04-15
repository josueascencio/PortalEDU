using Microsoft.AspNetCore.Mvc;
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


        //public IActionResult Index()
        //{
        //    //CentroEducativoVM centroEducativoVM = new CentroEducativoVM()
        //    //{
        //    //    centroEducativo = new Models.CentroEducativo(),
        //    //    ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo()
        //    //};

        //    return View();
        //}

        public async Task<IActionResult> Index()
        {

            //CalificacionesVM calificacionesVM = new CalificacionesVM()
            //{
            //    calificaciones = new Calificaciones(),
            //    alumno = new Alumno(),


            //    ListaAlumnos = _contenedorTrabajo.Alumno.GetAll(),
            //    ListaCalificaciones = _contenedorTrabajo.Calificaciones.GetAll(),


            //    //alumnos = _contenedorTrabajo.Alumno.GetAll().ToList(),
            //    //calificacionesList = _contenedorTrabajo.Calificaciones.GetAll().ToList(),


            //};
            //return View(calificacionesVM);


            var courses = _context.Calificaciones
                .Include(c => c.Alumno)
                .AsNoTracking();
            return View(await courses.ToListAsync());
        }



        //[HttpGet]
        //public IActionResult Create()
        //{
        //    CentroEducativoVM centroEducativoVM = new CentroEducativoVM()
        //    {
        //        centroEducativo = new Models.CentroEducativo(),
        //        ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo()
        //    };

        //    return View(centroEducativoVM);
        //}

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
            return Json(new { data = _contenedorTrabajo.Calificaciones.GetAll(includeProperties: ("Alumnos")) });
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
            return Json(new { success = true, message = "Calificaion borrada con exito" });
        }
        #endregion

    }


}
