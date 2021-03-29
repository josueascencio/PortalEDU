using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models.ViewModels;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEDU.WEB.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AlumnosController : Controller
    {


        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostinEnvironment;

        public AlumnosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostinEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostinEnvironment = hostinEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {

            //AlumnoVM alumnoVM = new AlumnoVM()
            //{
            //    alumno = new Alumno(),
                
            //    ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo(),
            //    ListaResponsable= _contenedorTrabajo.Responsable.GetListaResponsable(),


            //    // Articulo = new Models.

            //};

            return View();
        }



        [HttpGet]

        public IActionResult Create()
        {
            AlumnoVM alumnoVM = new AlumnoVM()
            {
                alumno = new Alumno(),
                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo(),
                ListaResponsable = _contenedorTrabajo.Responsable.GetListaResponsable(),

                // Articulo = new Models.

            };

            return View(alumnoVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AlumnoVM alumnoVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (alumnoVM.alumno.Id == 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\alumnos");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    alumnoVM.alumno.Foto = @"\imagenes\alumnos\" + nombreArchivo + extension;
                    //alumnoVM.alumno.update = DateTime.Now.ToString();

                    _contenedorTrabajo.Alumno.Add(alumnoVM.alumno);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }
            }

            alumnoVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            alumnoVM.ListaResponsable = _contenedorTrabajo.Responsable.GetListaResponsable();
            return View(alumnoVM);
        }


        [HttpGet]

        public IActionResult Edit(int? id)
        {

            AlumnoVM alumnoVM = new AlumnoVM()
            {

                alumno = new PortalEDU.Models.Alumno(),

                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo(),
                ListaResponsable = _contenedorTrabajo.Responsable.GetListaResponsable(),

            // Articulo = new Models.

        };

            if (id != null)
            {
                alumnoVM.alumno = _contenedorTrabajo.Alumno.Get(id.GetValueOrDefault());
            }
            alumnoVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            alumnoVM.ListaResponsable = _contenedorTrabajo.Responsable.GetListaResponsable();
            return View(alumnoVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AlumnoVM alumnoVM)
        {

            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var alumnoDesdeDb = _contenedorTrabajo.Alumno.Get(alumnoVM.alumno.Id);

                if (archivos.Count() > 0)
                {
                    // Editamos Imagenes
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\alumnos");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, alumnoDesdeDb.Foto.TrimStart('\\'));


                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    // Subimos nuevamente el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    alumnoVM.alumno.Foto = @"\imagenes\alumnos\" + nombreArchivo + nuevaExtension;


                    _contenedorTrabajo.Alumno.update(alumnoVM.alumno);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    // Aqui es cuando la imagen ya existe y no se reeemplaza 
                    // debe conservar la que ya esta en la base de datos
                    alumnoVM.alumno.Foto = alumnoDesdeDb.Foto;
                    // alumnoVM.alumno.FechaNacimiento = alumnoDesdeDb.FechaNacimiento;

                }

                _contenedorTrabajo.Alumno.update(alumnoVM.alumno);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            alumnoVM.alumno.FechaNacimiento = alumnoVM.alumno.FechaNacimiento;
            alumnoVM.ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo();
            alumnoVM.ListaResponsable = _contenedorTrabajo.Responsable.GetListaResponsable();
            return View(alumnoVM);
        }







        #region LLAMADAS A LAS API


        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Alumno.GetAll(includeProperties: "CentroEducativo,Responsable") });

        }


        public IActionResult Delete(int id)
        {
            var articuloDesdeDb = _contenedorTrabajo.Alumno.Get(id);
            string rutaDirectorioPrincipal = _hostinEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, articuloDesdeDb.Foto.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (articuloDesdeDb == null)

            {
                return Json(new { success = false, message = "Error al intentar borrar articulo" });

            }

            _contenedorTrabajo.Alumno.Remove(articuloDesdeDb);
            _contenedorTrabajo.Save();
                    
            return Json(new { success = true, message = "Articulo borrado con exito" });
        }




        #endregion

    }
}