using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Ciclo = new CicloRepository(_db);
            CentroEducativo = new CentroEducativoRepository(_db);
            Aula = new AulaRepository(_db);
            Alumno = new AlumnoRepository(_db);
            Docente = new DocenteRepository(_db);
            Responsable = new ResponsableRepository(_db);
            //Articulo = new ArticuloRepository(_db);
            //Slider = new SliderRepository(_db);
            //Usuario = new UsuarioRepository(_db);
        }

        public ICicloRepository Ciclo { get; private set; }
        public ICentroEducativoRepository CentroEducativo { get; private set; }
        public IAulaRepository Aula { get; private set; }
        public IAlumnoRepository Alumno { get; private set; }
        public IDocenteRepository Docente { get; private set; }

        public IResponsableRepository Responsable { get; private set; }
        //public IArticuloRepository Articulo { get; private set; }
        //public ISliderRepository Slider { get; private set; }
        //public IUsuarioRepository Usuario { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }


        public void Save()
        {

                _db.SaveChanges();

        }
    }
}
