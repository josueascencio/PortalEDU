using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class CentroEducativoRepository : Repository<CentroEducativo>, ICentroEducativoRepository
    {

        private readonly ApplicationDbContext _db;

        public CentroEducativoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        //public IEnumerable<SelectListItem> GetListaCentroEducativo()
        //{
        //    return _db.CentroEducativo.Select(i => new SelectListItem()
        //    {
        //        Text = i.Nombre.ToString(),
        //        Value = i.Id.ToString()
        //    });
        //}

     

        public void update(CentroEducativo centroEducativo)
        {
            var objDesdeDb = _db.CentroEducativo.FirstOrDefault(s => s.Id == centroEducativo.Id);
            objDesdeDb.Id = centroEducativo.Id;
            objDesdeDb.Nombre = centroEducativo.Nombre;
            objDesdeDb.Direccion = centroEducativo.Direccion;
            objDesdeDb.Correo = centroEducativo.Correo;
            objDesdeDb.Telefono = centroEducativo.Telefono;
            objDesdeDb.Tipo = centroEducativo.Tipo;
            objDesdeDb.Director = centroEducativo.Director;
            objDesdeDb.IdAnioAcademico = centroEducativo.IdAnioAcademico;

            _db.SaveChanges();
        }

        
    }
}
