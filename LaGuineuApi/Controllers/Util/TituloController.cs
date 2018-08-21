using System.Collections.Generic;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApi.Controllers
{

    [Route("api/[controller]"), EnableCors("MyPolicy")]
    public class TituloController : Controller
    {

        public IUtilService utilService = new UtilService();
        
        
        public List<Titulo> GetTitulos()
        {
            return utilService.GetTitulos();
        }

    }
}