using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalEDU.AccesoDatos.Data;
using PortalEDU.AccesoDatos.Data.Repository;
using PortalEDU.Models;
using PortalEDU.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEDU.WEB.Controllers
{
    [Area("Anonimo")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;

        public HomeController(IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
        }

        public IActionResult Index()
        {
           
            HomeVM homeVM = new HomeVM()
            {
                ListaAulas = _contenedorTrabajo.Aula.GetAll(),
                ListaCentroEducativo = _contenedorTrabajo.CentroEducativo.GetAll(),
                //AulaEnVM = new Aula(),
                //CentroEduEnVM = new CentroEducativo(),
                
                AulaEnVM = _contenedorTrabajo.Aula.GetAll().ToList(),
                CentroEduEnVM = _contenedorTrabajo.CentroEducativo.GetFirstOrDefault()



            };


            return View(homeVM);
        }


    



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}