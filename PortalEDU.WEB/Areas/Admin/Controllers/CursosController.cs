using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CursosController(ApplicationDbContext context, IContenedorTrabajo contenedorTrabajo)
        {
            _context = context;
            _contenedorTrabajo = contenedorTrabajo;
        }

        // GET: Admin/Cursoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Curso.Include(c => c.Aula);
            return View(await applicationDbContext.ToListAsync());
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
                CursoEnVM = new Curso(),
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




    }
}
