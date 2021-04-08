using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class DocenteRepository : Repository<Docente>, IDocenteRepository
    {

        private readonly ApplicationDbContext _db;

        public DocenteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaDocente()
        {
            return _db.Docente.Select(i => new SelectListItem()
            {
                Text = i.Nombre.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void Update(Docente docente)
        {
            var objDesdeDb = _db.Docente.FirstOrDefault(s => s.Id == docente.Id);
            objDesdeDb.Id = docente.Id;
            objDesdeDb.Nombre = docente.Nombre;
            objDesdeDb.Apellido = docente.Apellido;           
            objDesdeDb.Telefono = docente.Telefono;
            objDesdeDb.FechaNacimiento = docente.FechaNacimiento;
            objDesdeDb.GradoAcademico = docente.GradoAcademico;
            objDesdeDb.Direccion = docente.Direccion;
            objDesdeDb.Foto = docente.Foto;
            objDesdeDb.Sexo = docente.Sexo;
            objDesdeDb.update = docente.update;
            objDesdeDb.IdCentroEducativo = docente.IdCentroEducativo;
            objDesdeDb.CentroEducativo = docente.CentroEducativo;
            
            _db.SaveChanges();
        }

        
    }
}
