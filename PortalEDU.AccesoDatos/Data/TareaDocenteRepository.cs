using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class TareaDocenteRepository : Repository<TareaDocente>, ITareaDocenteRepository
    {

        private readonly ApplicationDbContext _db;

        public TareaDocenteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaTareaDocente()
        {
            return _db.TareaDocente.Select(i => new SelectListItem()
            {
                Text = i.Nombre.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void Update(TareaDocente tareaDocente)
        {
            var objDesdeDb = _db.TareaDocente.FirstOrDefault(s => s.Id == tareaDocente.Id);
            objDesdeDb.Id = tareaDocente.Id;
            objDesdeDb.Nombre = tareaDocente.Nombre;
            objDesdeDb.Descripcion = tareaDocente.Descripcion;
            objDesdeDb.FechaCreacion = tareaDocente.FechaCreacion;
            objDesdeDb.FechaFinalizacion = tareaDocente.FechaFinalizacion;
            objDesdeDb.Documento = tareaDocente.Documento;
            objDesdeDb.Puntuacion = tareaDocente.Puntuacion;
            objDesdeDb.Comentario = tareaDocente.Comentario;
            objDesdeDb.IdDocente = tareaDocente.IdDocente;
            objDesdeDb.Estado = tareaDocente.Estado;
            objDesdeDb.Update = tareaDocente.Update;
            objDesdeDb.IdCurso = tareaDocente.IdCurso;
            objDesdeDb.Docente = tareaDocente.Docente;
            objDesdeDb.Curso = tareaDocente.Curso;
            objDesdeDb.TareaAlumnos = tareaDocente.TareaAlumnos;
            //objDesdeDb.CentroEducativos = ciclo.CentroEducativos;




            _db.SaveChanges();
        }

        
    }
}
