using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
    {

        private readonly ApplicationDbContext _db;

        public AlumnoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaAlumno()
        {
            return _db.Alumno.Select(i => new SelectListItem()
            {
                Text = i.Nombre.ToString(),
                Value = i.Id.ToString()
            });
        }



        public void update(Alumno alumno)
        {
            var objDesdeDb = _db.Alumno.FirstOrDefault(s => s.Id == alumno.Id);
            objDesdeDb.Id = alumno.Id;
            objDesdeDb.Carnet = alumno.Carnet;
            objDesdeDb.Nombre = alumno.Nombre;           
            objDesdeDb.Apellido = alumno.Apellido;
            objDesdeDb.FechaNacimiento = alumno.FechaNacimiento;
            objDesdeDb.Direccion = alumno.Direccion;
            objDesdeDb.Foto = alumno.Foto;
            objDesdeDb.Sexo = alumno.Sexo;
            objDesdeDb.update = alumno.update;
            objDesdeDb.IdCentroEducativo = alumno.IdCentroEducativo;
            objDesdeDb.IdResponsable = alumno.IdResponsable;
            objDesdeDb.AlumnoCursos = alumno.AlumnoCursos;
            _db.SaveChanges();
        }

        
    }
}
