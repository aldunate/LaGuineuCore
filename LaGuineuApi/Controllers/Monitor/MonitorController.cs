using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
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
            Token token = (Token) Request.Properties["token"];
            return monitorService.GetMonitorEscuela(token.IdEscuela);
        }

        public MonitorModel Post(MonitorModel monitor) // List<MonitorTitulo> titulos
        {
            Token token = (Token)Request.Properties["token"];
            monitor.Monitor.IdEscuela = token.IdEscuela;
            return monitorService.EditarMonitor(monitor);
        }


    }
}