using Microsoft.AspNetCore.Hosting;
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
    public class SalasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostinEnvironment;

        public SalasController(ApplicationDbContext context, IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostinEnvironment)
        {
            _context = context;
            _contenedorTrabajo = contenedorTrabajo;
            _hostinEnvironment = hostinEnvironment;
        }

        public IActionResult Index()
        {
            SalaVM salaVM = new SalaVM()
            {



                SalaEnVM = new Models.Sala(),
                SalaComentarioEnVM = new Models.SalaComentario(),
                ListSala = _context.Sala.ToList(),
                ListSalaComentario = _context.SalaComentario.ToList(),
                ListaResponsable = _context.Responsable.ToList(),
                ListaResponsableItems = _contenedorTrabajo.Responsable.GetListaResponsable(),
                IESala = _context.Sala.ToList(),
                IESalaComentario = _context.SalaComentario.ToList(),
                



                //ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo()
            };


            return View(salaVM);
        }



        [HttpGet]
        public IActionResult Create()
        {
            SalaVM salaVM = new SalaVM()
            {



                SalaEnVM = new Models.Sala(),
                SalaComentarioEnVM = new Models.SalaComentario(),
                ListSala = _context.Sala.ToList(),
                ListSalaComentario = _context.SalaComentario.ToList(),
                IESala = _context.Sala.ToList(),
                IESalaComentario = _context.SalaComentario.ToList(),
                ListaDocenteItem = _contenedorTrabajo.Docente.GetListaDocente(),
                ListaResponsableItems =_contenedorTrabajo.Responsable.GetListaResponsable()                



                //ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo()
            };


            return View(salaVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SalaVM salaVM)
        {
            if (ModelState.IsValid)
            {
                _context.Sala.Add(salaVM.SalaEnVM);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            salaVM.ListaDocenteItem = _contenedorTrabajo.Docente.GetListaDocente();
            salaVM.ListaResponsableItems = _contenedorTrabajo.Responsable.GetListaResponsable();
            return View(salaVM);
        }





        public async Task<IActionResult> Details(int id)
        {
            SalaVM salaVM = new SalaVM()
            {



                SalaEnVM = new Models.Sala(),
                SalaComentarioEnVM = new Models.SalaComentario(),
                ListSala = _context.Sala.ToList(),
                ListSalaComentario = _context.SalaComentario.ToList(),
                ListaResponsable = _context.Responsable.ToList(),
                ListaDocente = _context.Docente.ToList(),

                IESala = _context.Sala.ToList(),
                IESalaComentario = _context.SalaComentario.ToList()


            };


            salaVM.SalaEnVM = await this._context.Sala.FindAsync(id);

            if (salaVM == null)
            {
                //this.TempData.AddInfoMessage("NO hay articulos");
                TempData["nosala"] = "No hay ninguna reunion";
                return this.RedirectToAction(nameof(Index));
            }

            //ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo()
            salaVM.ListSalaComentario = _context.SalaComentario.Where(x => x.IdSala == id).ToList();



            return this.View(salaVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SalaComentario(SalaVM salaVM)
        {
            if (ModelState.IsValid)
            {
                salaVM.SalaComentarioEnVM.IdSala = salaVM.SalaEnVM.Id;
                _context.SalaComentario.Add(salaVM.SalaComentarioEnVM);
                _contenedorTrabajo.Save();
                salaVM.ListSalaComentario = _context.SalaComentario.ToList();
                salaVM.SalaEnVM = salaVM.SalaEnVM;
               
                return View("Details",salaVM);
            }
            //centroEducativoVM.ListaCiclo = _contenedorTrabajo.Ciclo.GetListaCiclo();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSalaComentario(int id)
        {
            try
            {
                var salaComentario = _context.SalaComentario.Where(x => x.Id == id);
                _context.SalaComentario.Remove(salaComentario.FirstOrDefault());
                _context.SaveChanges();

                SalaVM salaVM = new SalaVM()
                {
                    ListSala = _context.Sala.ToList(),
                    
                    ListSalaComentario = _context.SalaComentario.ToList(),
                    ListaResponsable = _context.Responsable.ToList(),
                    ListaDocente = _context.Docente.ToList(),

                    IESala = _context.Sala.ToList(),
                    IESalaComentario = _context.SalaComentario.ToList()

                };

                return Json(new { success = true, message = "Centro Educativo borrado con exito" });


            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Por favor revise la informacion proporcionada.");
            }


            return RedirectToAction(nameof(Index));

        }




        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _context.SalaComentario.Find(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Centro Educativo" });
            }

            _context.SalaComentario.Remove(objFromDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Centro Educativo borrado con exito" });
        }



    }
}