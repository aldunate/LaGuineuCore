using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class AppMMonitorController : Controller
    {

        public IMonitorService monitorService = new MonitorService();
        public ITokenService tokenService = new TokenService();

        // GET: Monitor
        public Object Get()
        {
            Token token = (Token)Request.Properties["token"];
            if(token.IdMonitor != null)
            {
                return monitorService.GetMonitor((int)token.IdMonitor);
            }
            else
            {
                return null;
            }
        }
        public List<Clase> GetClasesFecha(DateTime fecha)
        {
            Token token = (Token)Request.Properties["token"];
            return monitorService.GetClasesMonitorFecha(fecha,(int)token.IdMonitor);
        }

        public MonitorModel Post(MonitorModel monitor) // List<MonitorTitulo> titulos
        {
            monitor.Operacion = "Editar";
            Token token = (Token)Request.Properties["token"];
            monitor.Monitor.IdEscuela = token.IdEscuela;
            return monitorService.EditarMonitor(monitor);
        }
    }
}