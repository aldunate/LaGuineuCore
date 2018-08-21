using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class MonitorController : Controller
    {

        public IMonitorService monitorService = new MonitorService();
        public ITokenService tokenService = new TokenService();

        // GET: Monitor
        public Object Get(int id)
        {
            return monitorService.GetMonitor(id);
        }

        public List<Monitor> GetMonitores()
        {
            var body = Request.Body;
            Token token = new Token();
            return monitorService.GetMonitorEscuela(token.IdEscuela);
        }

        public MonitorModel Post(MonitorModel monitor) // List<MonitorTitulo> titulos
        {
            var body = Request.Body;
            Token token = new Token();
            monitor.Monitor.IdEscuela = token.IdEscuela;
            return monitorService.EditarMonitor(monitor);
        }


    }
}