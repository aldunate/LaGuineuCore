using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    public class NivelController : Controller
    {
        // Curso
        private IUtilService utilService = new UtilService();

        public List<Object> GetNiveles()
        {
            return null;
            //return utilService.GetNiveles();
        }



    }
}