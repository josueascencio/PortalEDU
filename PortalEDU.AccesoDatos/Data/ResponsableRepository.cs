using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class ResponsableRepository : Repository<Responsable>, IResponsableRepository
    {

        private readonly ApplicationDbContext _db;

        public ResponsableRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaResponsable()
        {
            return _db.Responsable.Select(i => new SelectListItem()
            {
                Text = i.Nombre.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void Update(Responsable responsable)
        {
            var objDesdeDb = _db.Responsable.FirstOrDefault(s => s.Id == responsable.Id);
            objDesdeDb.Id = responsable.Id;
            objDesdeDb.Nombre = responsable.Nombre;
            objDesdeDb.Apellido = responsable.Apellido;           
            objDesdeDb.Telefono = responsable.Telefono;
            objDesdeDb.Profesion = responsable.Profesion;
            objDesdeDb.Direccion = responsable.Direccion;
            objDesdeDb.Foto = responsable.Foto;
            objDesdeDb.TelefonoTrabajo = responsable.TelefonoTrabajo;
            objDesdeDb.AlumnoLista = responsable.AlumnoLista;
            objDesdeDb.update = responsable.update;
            
            
            _db.SaveChanges();
        }

        
    }
}
