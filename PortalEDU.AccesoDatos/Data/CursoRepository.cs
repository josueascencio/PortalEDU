using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class CursoRepository : Repository<Curso>, ICursoRepository
    {

        private readonly ApplicationDbContext _db;

        public CursoRepository (ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaCurso()
        {
            return _db.Curso.Select(i => new SelectListItem()
            {
                Text = i.Nombre.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void Update(Curso curso)
        {
            var objDesdeDb = _db.Curso.FirstOrDefault(s => s.Id == curso.Id);
            objDesdeDb.Id = curso.Id;
            objDesdeDb.Nombre = curso.Nombre;
            objDesdeDb.Descripcion = curso.Descripcion;           
            objDesdeDb.FechaInicio = curso.FechaInicio;
            objDesdeDb.FechaFinal = curso.FechaFinal;
            objDesdeDb.Estado = curso.Estado;
            objDesdeDb.IdAula = curso.IdAula;
            objDesdeDb.Update = curso.Update;
            objDesdeDb.AlumnoCursos = curso.AlumnoCursos;
            objDesdeDb.DocenteCursos = curso.DocenteCursos;
            objDesdeDb.TareaDocente = curso.TareaDocente;
            
            _db.SaveChanges();
        }

        
    }
}
