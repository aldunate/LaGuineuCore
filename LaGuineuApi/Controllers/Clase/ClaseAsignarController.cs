using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class ClaseAsignarController : Controller
    {

        public IClaseService claseService = new ClaseService();
        public ITokenService tokenService = new TokenService();

        
        public int PostClase(ClaseModel clase)
        {
            Token token = (Token)Request.Properties["token"];
            return claseService.PostAsignada(clase);
        }

    }
}