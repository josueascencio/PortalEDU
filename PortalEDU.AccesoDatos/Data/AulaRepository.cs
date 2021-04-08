using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class AulaRepository : Repository<Aula>, IAulaRepository
    {

        private readonly ApplicationDbContext _db;

        public AulaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaAula()
        {
            return _db.Aula.Select(i => new SelectListItem()
            {
                Text = i.Nombre.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void update(Aula aula)
        {
            var objDesdeDb = _db.Aula.FirstOrDefault(s => s.Id == aula.Id);
            objDesdeDb.Id = aula.Id;
            objDesdeDb.Nombre = aula.Nombre;
            objDesdeDb.Seccion = aula.Seccion;
            objDesdeDb.IdCentroEducativo = aula.IdCentroEducativo;
            objDesdeDb.update = aula.update;
            objDesdeDb.CentroEducativo = aula.CentroEducativo;
            

            //objDesdeDb.CentroEducativos = ciclo.CentroEducativos;




            _db.SaveChanges();
        }

        
    }
}
