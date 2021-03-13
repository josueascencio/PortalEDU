using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class CicloRepository : Repository<Ciclo>, ICicloRepository
    {

        private readonly ApplicationDbContext _db;

        public CicloRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaCiclo()
        {
            return _db.Ciclo.Select(i => new SelectListItem()
            {
                Text = i.AnioAcademico.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void update(Ciclo ciclo)
        {
            var objDesdeDb = _db.Ciclo.FirstOrDefault(s => s.Id == ciclo.Id);
            objDesdeDb.AnioAcademico = ciclo.AnioAcademico;
            objDesdeDb.Id = ciclo.Id;
            //objDesdeDb.CentroEducativos = ciclo.CentroEducativos;




            _db.SaveChanges();
        }

        
    }
}
