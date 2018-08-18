using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class NivelController : Controller
    {
        // Curso
        private IUtilService utilService = new UtilService();

        public List<Nivel> GetNiveles()
        {
            return utilService.GetNiveles();
        }



    }
}