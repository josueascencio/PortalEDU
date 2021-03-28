using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEDU.WEB.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class DocentesController : Controller
    {


        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostinEnvironment;

        public DocentesController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostinEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostinEnvironment = hostinEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {

            //ArticuloVM artivm = new ArticuloVM()
            //{
            //    articulo = new PortalEDU.Models.Articulo(),
            //    ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategoria()
            // // Articulo = new Models.

            //};

            return View();
        }



        [HttpGet]
        public IActionResult Create()
        {
            DocenteVM docenteVM = new DocenteVM()
            {
                docente = new PortalEDU.Models.Docente(),
                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo()
                 

            };

            return View(docenteVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DocenteVM docenteVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (docenteVM.docente.Id == 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\docentes");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    docenteVM.docente.Foto = @"\imagenes\docentes\" + nombreArchivo + extension;
                    //alumnoVM.alumno.update = DateTime.Now.ToString();

                    _contenedorTrabajo.Docente.Add(docenteVM.docente);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }
            }

            docenteVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            return View(docenteVM);
        }


        [HttpGet]

        public IActionResult Edit(int? id)
        {
            DocenteVM docenteVM = new DocenteVM()
            {
                docente = new PortalEDU.Models.Docente(),
                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo()
                // Articulo = new Models.

            };

            if (id != null)
            {
                docenteVM.docente = _contenedorTrabajo.Docente.Get(id.GetValueOrDefault());
            }
            docenteVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            return View(docenteVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DocenteVM docenteVM)
        {

            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var docenteDesdeDb = _contenedorTrabajo.Docente.Get(docenteVM.docente.Id);

                if (archivos.Count() > 0)
                {
                    // Editamos Imagenes
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\docentes");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, docenteDesdeDb.Foto.TrimStart('\\'));


                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    // Subimos nuevamente el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    docenteVM.docente.Foto = @"\imagenes\alumnos\" + nombreArchivo + nuevaExtension;


                    _contenedorTrabajo.Docente.Update(docenteVM.docente);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    // Aqui es cuando la imagen ya existe y no se reeemplaza 
                    // debe conservar la que ya esta en la base de datos
                    docenteVM.docente.Foto = docenteDesdeDb.Foto;
                    // alumnoVM.alumno.FechaNacimiento = alumnoDesdeDb.FechaNacimiento;

                }

                _contenedorTrabajo.Docente.Update(docenteVM.docente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            //alumnoVM.alumno.FechaNacimiento = alumnoVM.alumno.FechaNacimiento;
            docenteVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            return View(docenteVM);
        }







        #region LLAMADAS A LAS API


        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Docente.GetAll(includeProperties: "CentroEducativo") });

        }


        public IActionResult Delete(int id)
        {
            var docenteDesdeDb = _contenedorTrabajo.Docente.Get(id);
            string rutaDirectorioPrincipal = _hostinEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, docenteDesdeDb.Foto.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (docenteDesdeDb == null)

            {
                return Json(new { success = false, message = "Error al intentar borrar Docente" });

            }

            _contenedorTrabajo.Docente.Remove(docenteDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Docente borrado con exito" });
        }




        #endregion

    }
}