using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class CalificacionesRepository : Repository<Calificaciones>, ICalificacionesRepository
    {

        private readonly ApplicationDbContext _db;

        public CalificacionesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaCalificaciones()
        {
            return _db.Calificaciones.Select(i => new SelectListItem()
            {
                Text = i.Promedio.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void Update(Calificaciones calificaciones)
        {
            var objDesdeDb = _db.Calificaciones.FirstOrDefault(s => s.Id == calificaciones.Id);
            objDesdeDb.Id = calificaciones.Id;
            objDesdeDb.PrimerTrimestre = calificaciones.PrimerTrimestre;
            objDesdeDb.SegundoTrimestre = calificaciones.SegundoTrimestre;           
            objDesdeDb.TercerTrimestre = calificaciones.TercerTrimestre;
            objDesdeDb.CuartoTrimestre = calificaciones.CuartoTrimestre;
            objDesdeDb.Promedio = calificaciones.Promedio;
            objDesdeDb.Alumno = calificaciones.Alumno;
            objDesdeDb.IdAlumno = calificaciones.IdAlumno;
            objDesdeDb.Update = calificaciones.Update;
          
            _db.SaveChanges();
        }

        
    }
}
