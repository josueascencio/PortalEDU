using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PortalEDU.AccesoDatos.Data;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using PortalEDU.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vereyon.Web;

namespace PortalEDU.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResponsablesController : Controller
    {


        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostinEnvironment;
        private readonly IFlashMessage _flashMessage;

        public ResponsablesController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostinEnvironment, IFlashMessage flashMessage)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostinEnvironment = hostinEnvironment;
            _flashMessage = flashMessage;
        }


        [HttpGet]
        public IActionResult Index()
        {

            //    //ResponsableVM artivm = new ResponsableVM()
            //    //{
            //    //    responsable = new PortalEDU.Models.Responsable(),
            //    //    ListaAlumnos = _contenedorTrabajo.Alumno.GetListaAlumno()
            //    //    // Articulo = new Models.

            //    //};


            //    //////Funciona

            //    // var responsables = _context.Responsable.Include( c => c.AlumnoListaProp).AsNoTracking();



            //    //////Funciona

            //    //List<Responsable> objlist = _context.Responsable.ToList();

            //    //foreach (var obj in objlist)
            //    //{
            //    //    _context.Entry(obj).Collection(u => u.AlumnoListaProp).Load();

            //    //    foreach (var ResponAlumno in obj.AlumnoListaProp)
            //    //    {
            //    //        _context.Entry(ResponAlumno).Reference(a => a.Responsable).Load();
            //    //    }

            //    //   }


            return View();

        }



        [HttpGet]

        public IActionResult Create(int? id)
        {
            ResponsableVM responsableVM = new ResponsableVM()
            {
                responsable = new Responsable(),
                ListaAlumnos = _contenedorTrabajo.Alumno.GetListaAlumno()
                //ListaResponsable = _contenedorTrabajo.Responsable.GetListaResponsable(),

                // Articulo = new Models.

            };

            return View(responsableVM);





        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResponsableVM responsableVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;


                if (responsableVM.responsable.Id == 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\responsables");

                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    responsableVM.responsable.Foto = @"\imagenes\responsables\" + nombreArchivo + extension;
                    //alumnoVM.alumno.update = DateTime.Now.ToString();

                    _contenedorTrabajo.Responsable.Add(responsableVM.responsable);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }
            }

            responsableVM.ListaAlumnos = _contenedorTrabajo.Alumno.GetListaAlumno();

            return View(responsableVM);


        }





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(ResponsableVM responsableVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string webRootPath = _hostinEnvironment.WebRootPath;
        //        var archivos = HttpContext.Request.Form.Files;
        //        if (archivos.Count > 0)
        //        {
        //            string fileName = Guid.NewGuid().ToString();
        //            var uploads = Path.Combine(webRootPath, @"imagenes\responsables");
        //            var extenstion = Path.GetExtension(archivos[0].FileName);

        //            if (responsableVM.responsable.Foto != null)
        //            {
        //                //this is an edit and we need to remove old image
        //                var imagePath = Path.Combine(webRootPath, responsableVM.responsable.Foto.TrimStart('\\'));
        //                if (System.IO.File.Exists(imagePath))
        //                {
        //                    System.IO.File.Delete(imagePath);
        //                }
        //            }
        //            using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
        //            {
        //                archivos[0].CopyTo(filesStreams);
        //            }
        //            responsableVM.responsable.Foto = @"\imagenes\responsables\" + fileName + extenstion;
        //        }
        //        else
        //        {
        //            //update when they do not change the image
        //            if (responsableVM.responsable.Id != 0)
        //            {
        //                Responsable objFromDb = _contenedorTrabajo.Responsable.Get(responsableVM.responsable.Id);
        //                responsableVM.responsable.Foto = objFromDb.Foto;
        //            }
        //        }


        //        if (responsableVM.responsable.Id == 0)
        //        {
        //            _contenedorTrabajo.Responsable.Add(responsableVM.responsable);

        //        }
        //        else
        //        {
        //            _contenedorTrabajo.Responsable.Update(responsableVM.responsable);
        //        }
        //        _contenedorTrabajo.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        //    IEnumerable<Category> CatList = await _unitOfWork.Category.GetAllAsync();
        //        //    productVM.CategoryList = CatList.Select(i => new SelectListItem
        //        //    {
        //        //        Text = i.Name,
        //        //        Value = i.Id.ToString()
        //        //    });
        //        //    productVM.CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
        //        //    {
        //        //        Text = i.Name,
        //        //        Value = i.Id.ToString()
        //        //    });
        //        if (responsableVM.responsable.Id != 0)
        //    {
        //        responsableVM.responsable = _contenedorTrabajo.Responsable.Get(responsableVM.responsable.Id);
        //    }
        //}
        //    return View(responsableVM);
        //}








        public IActionResult Edit(int? id)
        {

            ResponsableVM responsableVM = new ResponsableVM()
            {

                responsable = new PortalEDU.Models.Responsable(),

                //ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetListaCentroEducativo(),
                //ListaResponsable = _contenedorTrabajo.Responsable.GetListaResponsable(),
                ListaAlumnos = _contenedorTrabajo.Alumno.GetListaAlumno()
            

                // Articulo = new Models.

            };

            if (id != null)
            {
                responsableVM.responsable = _contenedorTrabajo.Responsable.Get(id.GetValueOrDefault());
            }
            
            return View(responsableVM);
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ResponsableVM responsableVM)
        {

            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var responsableDesdeDb = _contenedorTrabajo.Responsable.Get(responsableVM.responsable.Id);

                if (archivos.Count() > 0)
                {
                    // Editamos Imagenes
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\responsables");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);
                    var rutaImagen = Path.Combine(rutaPrincipal, responsableDesdeDb.Foto.TrimStart('\\'));


                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    // Subimos nuevamente el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    responsableVM.responsable.Foto = @"\imagenes\responsables\" + nombreArchivo + nuevaExtension;


                    _contenedorTrabajo.Responsable.Update(responsableVM.responsable);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    // Aqui es cuando la imagen ya existe y no se reeemplaza 
                    // debe conservar la que ya esta en la base de datos
                    responsableVM.responsable.Foto = responsableDesdeDb.Foto;
                    // alumnoVM.alumno.FechaNacimiento = alumnoDesdeDb.FechaNacimiento;

                }

                _contenedorTrabajo.Responsable.Update(responsableVM.responsable);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
           
            responsableVM.ListaAlumnos = _contenedorTrabajo.Alumno.GetListaAlumno();
            return View(responsableVM);
        }























        #region LLAMADAS A LAS API


        [HttpGet]

        //public IActionResult GetAll()
        //{
        //    return Json(new { data = _contenedorTrabajo.Responsable.GetAll(includeProperties: "Alumno") });

        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _contenedorTrabajo.Responsable.GetAll(includeProperties: "AlumnoLista");

            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var responsableDesdeDb = _contenedorTrabajo.Responsable.Get(id);
          


            if (responsableDesdeDb == null)

            {
                TempData["Error"] = "Error al eliminar responsable";
                return Json(new { success = false, message = "Error mientras eliminaba" });


            }


            try
            {
                _contenedorTrabajo.Responsable.Remove(responsableDesdeDb);
                _contenedorTrabajo.Save();

                TempData["Success"] = "Registro eliminado correctamente";
                return Json(new { success = true, message = "Eliminacion exitosa" });

            }



            catch (Exception)
            {
                string rutaDirectorioPrincipal = _hostinEnvironment.WebRootPath;
                var rutaImagen = Path.Combine(rutaDirectorioPrincipal, responsableDesdeDb.Foto.TrimStart('\\'));

                if (System.IO.File.Exists(rutaImagen) && responsableDesdeDb.Nombre==null)
                {
                    System.IO.File.Delete(rutaImagen);
                }

                TempData["error"] = "Error al eliminar responsable";
                return Json(new { success = false, message = "El registro tiene alumnos asociados" });
            }

            return View(responsableDesdeDb);

        }











        #endregion






    }
}