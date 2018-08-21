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
    public class RespuestaController : Controller
    {
       
        // GET: Monitor
        public Object GetDeportes()
        {
            return null;
        }

        public Object GetDeportes(int idEscuela)
        {
            return null;
        }


    }
}