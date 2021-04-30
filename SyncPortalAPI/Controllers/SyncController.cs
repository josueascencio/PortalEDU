using Dotmim.Sync.Web.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncPortalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        // The WebServerManager instance is useful to manage all
        // the Web server orchestrators registered in the Startup.cs
        private WebServerManager manager;

        // Injected thanks to Dependency Injection
        public SyncController(WebServerManager manager) => this.manager = manager;

        /// <summary>
        /// This POST handler is mandatory to handle all the sync process
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task Post() => await manager.HandleRequestAsync(this.HttpContext);

        /// <summary>
        /// This GET handler is optional. It allows you to see the configuration hosted on the server
        /// The configuration is shown only if Environmenent == Development
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task Get() => await manager.HandleRequestAsync(this.HttpContext);
    }
}
