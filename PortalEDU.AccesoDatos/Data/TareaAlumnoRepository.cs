using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class TareaAlumnoRepository : Repository<TareaAlumno>, ITareaAlumnoRepository
    {

        private readonly ApplicationDbContext _db;

        public TareaAlumnoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaTareaAlumno()
        {
            return _db.TareaAlumno.Select(i => new SelectListItem()
            {
                Text = i.Documento.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void Update(TareaAlumno tareaAlumno)
        {
            var objDesdeDb = _db.TareaAlumno.FirstOrDefault(s => s.Id == tareaAlumno.Id);
            objDesdeDb.Id = tareaAlumno.Id;
            objDesdeDb.Documento = tareaAlumno.Documento;
            objDesdeDb.Update = tareaAlumno.Update;
            objDesdeDb.IdTareaDocente = tareaAlumno.IdTareaDocente;
            objDesdeDb.IdAlumno = tareaAlumno.IdAlumno;

            //objDesdeDb.CentroEducativos = ciclo.CentroEducativos;




            _db.SaveChanges();
        }


    }
}
