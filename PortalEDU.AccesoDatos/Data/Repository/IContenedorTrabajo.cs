using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICicloRepository Ciclo { get; }
        ICentroEducativoRepository CentroEducativo { get; }

        IAulaRepository Aula { get; }


        void Save();
    }
}
