using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEDU.AccesoDatos.Data;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using PortalEDU.Models.ViewModels;

namespace PortalEDU.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostinEnvironment;

        public CursosController(ApplicationDbContext context, IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostinEnvironment)
        {
            _context = context;
            _contenedorTrabajo = contenedorTrabajo;
            _hostinEnvironment = hostinEnvironment;
        }

        // GET: Admin/Cursoes
        public IActionResult Index()
        {
            //var applicationDbContext = _context.Curso.Include(c => c.Aula);
            //return View(await applicationDbContext.ToListAsync());

            CursoCardVM cursoCardVM = new CursoCardVM()
            {
                curso = new Curso(),
                ListaAulas = _contenedorTrabajo.Aula.GetAll(),
                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetAll(),
                //AulaEnVM = new Aula(),
                //CentroEduEnVM = new CentroEducativo(),

                CursoEnVM = _contenedorTrabajo.Curso.GetAll().ToList(),

                DocenteEnVM = _contenedorTrabajo.Docente.GetAll().ToList(),

                AlumnoEnVM = _contenedorTrabajo.Alumno.GetAll().ToList(),

                ListaCursos = _contenedorTrabajo.Curso.GetAll(),
                //AulaEnVM = _contenedorTrabajo.Aula.GetAll().ToList(),
                CentroEduEnVM = _contenedorTrabajo.CentroEducativo.GetFirstOrDefault(),



            };

            if (TempData["tareaerror"] != null)
                ViewBag.errortarea = TempData["tareaerror"].ToString();

            if (TempData["tareaexito"] != null)
                ViewBag.tareaexito = TempData["tareaexito"].ToString();

            return View(cursoCardVM);
        }

        // GET: Admin/Cursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .Include(c => c.Aula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Admin/Cursoes/Create
        public IActionResult Create()
        {
            ViewData["IdAula"] = new SelectList(_context.Aula, "Id", "Nombre");
            return View();
        }

        // POST: Admin/Cursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaInicio,FechaFinal,Estado,IdAula,Update")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAula"] = new SelectList(_context.Aula, "Id", "Nombre", curso.IdAula);
            return View(curso);
        }

        // GET: Admin/Cursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["IdAula"] = new SelectList(_context.Aula, "Id", "Nombre", curso.IdAula);
            return View(curso);
        }

        // POST: Admin/Cursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaInicio,FechaFinal,Estado,IdAula,Update")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAula"] = new SelectList(_context.Aula, "Id", "Nombre", curso.IdAula);
            return View(curso);
        }

        // GET: Admin/Cursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .Include(c => c.Aula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Admin/Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }





        public IActionResult CarCursos()
        {

            CursoCardVM homeVM = new CursoCardVM()
            {
                //CursoEnVM = new Curso(),
                ListaAulas = _contenedorTrabajo.Aula.GetAll(),
                ListaDocentes = _contenedorTrabajo.Docente.GetAll(),
                //ListaTareas = _contenedorTrabajo.TareaDocente.GetAll(),
                ListaCursos = _contenedorTrabajo.Curso.GetAll(),
                //AulaEnVM = new Aula(),
                //CentroEduEnVM = new CentroEducativo(),

                //AulaEnVM = _contenedorTrabajo.Aula.GetAll().ToList(),
                //CentroEduEnVM = _contenedorTrabajo.CentroEducativo.GetAll().ToList(),



            };


            return View(homeVM);
        }


        public IActionResult Tareas(int? id)
        {
            TareaDocenteVM tareaDocenteVM = new TareaDocenteVM()
            {
                //TareaDocente = new TareaDocente(),
                AulaVM = new Aula(),

                CursoVM = new Curso(),

                ListaCursoItem = _contenedorTrabajo.Curso.GetListaCurso(),
                ListaDocenteItem = _contenedorTrabajo.Docente.GetListaDocente(),
                ListaTareaDocenteItem = _contenedorTrabajo.TareaDocente.GetListaTareaDocente(),

                DocenteList = _contenedorTrabajo.Docente.GetAll().ToList(),
                CursoList = _contenedorTrabajo.Curso.GetAll().ToList(),

                TareaDocenteList = _contenedorTrabajo.TareaDocente.GetAll().Where(m => m.IdCurso == id).ToList(),

                AulaList = _contenedorTrabajo.Aula.GetAll().ToList(),

                //TareaDocente = _contenedorTrabajo.TareaDocente.GetFirstOrDefault(m => m.IdCurso == id)



            };

            ViewBag.IdCurso = id;

            //TimeSpan diferencia = tareaDocenteVM.TareaDocente.FechaFinalizacion.Value.Date - tareaDocenteVM.TareaDocente.FechaCreacion.Value.Date;

            //ViewBag.fechafin = diferencia.TotalDays;

            return View(tareaDocenteVM);

        }



        public IActionResult _TareaDocentePartial(int? id)
        {

            TareaDocenteVM tareaDocenteVM = new TareaDocenteVM()
            {
                //TareaDocente = new TareaDocente(),
                AulaVM = new Aula(),

                CursoVM = new Curso(),

                ListaCursoItem = _contenedorTrabajo.Curso.GetListaCurso(),
                ListaDocenteItem = _contenedorTrabajo.Docente.GetListaDocente(),
                ListaTareaDocenteItem = _contenedorTrabajo.TareaDocente.GetListaTareaDocente(),

                DocenteList = _contenedorTrabajo.Docente.GetAll().ToList(),
                CursoList = _contenedorTrabajo.Curso.GetAll().ToList(),
                TareaDocenteList = _contenedorTrabajo.TareaDocente.GetAll().ToList(),

                AulaList = _contenedorTrabajo.Aula.GetAll().ToList(),

                //TareaDocente = _contenedorTrabajo.TareaDocente.GetFirstOrDefault(m => m.IdCurso == id)

            };

            ViewBag.IdCurso = tareaDocenteVM.CursoVM.Id;
            return PartialView("_TareaDocentePartial", tareaDocenteVM);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _TareaAlumnoPartial(TareaDocenteVM tareaDocenteVM)
        {
            {
                if (ModelState.IsValid)
                {
                    try
                    {


                        if (tareaDocenteVM.TareaAlumnoVM.Id == 0)
                        {
                           


                                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                                var archivos = HttpContext.Request.Form.Files;

                                if (tareaDocenteVM.TareaAlumnoVM.Id == 0)
                                {
                                if (archivos.Count() <= 0)
                                {
                                    //ViewBag.errortarea = "Hubo un error al enviar su tare intente nuevamente";
                                    TempData["tareaerror"] = "Hubo un error al enviar su tarea, por favor verifique todos los datos e intente nuevamente";

                                    return RedirectToAction("index", "cursos");
                                }
                                    //string nombreArchivo = Guid.NewGuid().ToString();
                                    string nombreArchivo = Path.GetFileName(archivos[0].FileName);
                                    var subidas = Path.Combine(rutaPrincipal, @"documentos\tareaalumno");
                                    var extension = Path.GetExtension(archivos[0].FileName);
                              
                                using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo/* + extension*/), FileMode.Create))
                                    {
                                        archivos[0].CopyTo(fileStreams);
                                    }

                                    tareaDocenteVM.TareaAlumnoVM.Documento = @"\documentos\tareaalumno\" + nombreArchivo /*+ extension*/;
                                    //alumnoVM.alumno.update = DateTime.Now.ToString();

                                    _contenedorTrabajo.TareaAlumno.Add(tareaDocenteVM.TareaAlumnoVM);
                                    _contenedorTrabajo.Save();

                                TempData["tareaexito"] = "Felicidades su tarea ha sido enviada exitosamente";

                                return RedirectToAction("index", "cursos");

                               

                                



                              
                            }
                           
                        }
                        else
                        {
                            string rutaPrincipal = _hostinEnvironment.WebRootPath;
                            var archivos = HttpContext.Request.Form.Files;

                            var responsableDesdeDb = _contenedorTrabajo.TareaAlumno.Get(tareaDocenteVM.TareaAlumnoVM.Id);

                            if (archivos.Count() > 0)
                            {
                                try
                                {   // Editamos Imagenes
                                    string nombreArchivo = Guid.NewGuid().ToString();
                                    var subidas = Path.Combine(rutaPrincipal, @"documentos\tareaalumno");
                                    var extension = Path.GetExtension(archivos[0].FileName);
                                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);
                                    var rutaImagen = Path.Combine(rutaPrincipal, responsableDesdeDb.Documento.TrimStart('\\'));


                                    if (System.IO.File.Exists(rutaImagen))
                                    {
                                        System.IO.File.Delete(rutaImagen);
                                    }

                                    // Subimos nuevamente el archivo
                                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo /*+ nuevaExtension*/), FileMode.Create))
                                    {
                                        archivos[0].CopyTo(fileStreams);
                                    }

                                    tareaDocenteVM.TareaAlumnoVM.Documento = @"\documentos\tareaalumno\" + nombreArchivo /*+ nuevaExtension*/;


                                    _contenedorTrabajo.TareaAlumno.Update(tareaDocenteVM.TareaAlumnoVM);
                                    _contenedorTrabajo.Save();

                                    TempData["tareaexito"] = "Felicidades su tarea ha sido enviada exitosamente";

                                    return RedirectToAction("index", "cursos");
                                }
                                catch (DbUpdateException)
                                {
                                    ModelState.AddModelError("", "Por favor revise la informacion proporcionada.");
                                }

                            }


                            else
                            {
                                // Aqui es cuando la imagen ya existe y no se reeemplaza 
                                // debe conservar la que ya esta en la base de datos
                                tareaDocenteVM.TareaAlumnoVM.Documento = responsableDesdeDb.Documento;
                                // alumnoVM.alumno.FechaNacimiento = alumnoDesdeDb.FechaNacimiento;

                            }

                            _contenedorTrabajo.TareaAlumno.Update(tareaDocenteVM.TareaAlumnoVM);
                            _contenedorTrabajo.Save();
                            TempData["tareaexito"] = "Felicidades su tarea ha sido enviada exitosamente";

                            return RedirectToAction("index", "cursos");
                        }




                        //return PartialView("_TareaDocentePartial");
                    }

                    catch (DbUpdateException)
                    {

                        ModelState.AddModelError("", "Por favor revise la informacion proporcionada.");

                        return View();
                    }
                }

                return View();


            }

        }

        //    [HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult _TareaAlumnoPartial(TareaDocenteVM tareaDocenteVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string rutaPrincipal = _hostinEnvironment.WebRootPath;
        //        var archivos = HttpContext.Request.Form.Files;

        //        if (tareaDocenteVM.TareaAlumnoVM.Id == 0)
        //        {
        //            //string nombreArchivo = Guid.NewGuid().ToString();
        //            string nombreArchivo = Path.GetFileName(archivos[0].FileName);
        //            var subidas = Path.Combine(rutaPrincipal, @"documentos\tareaalumno");
        //            var extension = Path.GetExtension(archivos[0].FileName);

        //            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo/* + extension*/), FileMode.Create))
        //            {
        //                archivos[0].CopyTo(fileStreams);
        //            }

        //            tareaDocenteVM.TareaAlumnoVM.Documento = @"\documentos\tareaalumno\" + nombreArchivo /*+ extension*/;
        //            //alumnoVM.alumno.update = DateTime.Now.ToString();

        //            _contenedorTrabajo.TareaAlumno.Add(tareaDocenteVM.TareaAlumnoVM);
        //            _contenedorTrabajo.Save();


        //            return RedirectToAction("Tareas");
        //        }
        //    }

        //    tareaDocenteVM.ListaCursoItem = _contenedorTrabajo.Curso.GetListaCurso();
        //    tareaDocenteVM.ListaDocenteItem = _contenedorTrabajo.Docente.GetListaDocente();
        //    tareaDocenteVM.DocenteList = _contenedorTrabajo.Docente.GetAll().ToList();
        //    tareaDocenteVM.CursoList = _contenedorTrabajo.Curso.GetAll().ToList();
        //    tareaDocenteVM.AulaList = _contenedorTrabajo.Aula.GetAll().ToList();
        //    return View(tareaDocenteVM);
        //}







    }
}
