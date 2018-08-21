using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    public class AppMMonitorController : Controller
    {

        public IMonitorService monitorService = new MonitorService();
        public ITokenService tokenService = new TokenService();

        // GET: Monitor
        public Object Get()
        {
            var body = Request.Body;
            Token token = new Token();
            if (token.IdMonitor != 0)
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
            var body = Request.Body;
            Token token = new Token();
            return monitorService.GetClasesMonitorFecha(fecha,(int)token.IdMonitor);
        }

        public MonitorModel Post(MonitorModel monitor) // List<MonitorTitulo> titulos
        {
            monitor.Operacion = "Editar";
            var body = Request.Body;
            Token token = new Token();
            monitor.Monitor.IdEscuela = token.IdEscuela;
            return monitorService.EditarMonitor(monitor);
        }
    }
}