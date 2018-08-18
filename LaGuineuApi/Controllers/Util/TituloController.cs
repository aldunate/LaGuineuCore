using System.Collections.Generic;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApi.Controllers
{
    [Route("api/[controller]")]
    public class TituloController : Controller
    {

        public IUtilService utilService = new UtilService();
        
        
        public List<Titulo> GetTitulos()
        {
            return utilService.GetTitulos();
        }

    }
}