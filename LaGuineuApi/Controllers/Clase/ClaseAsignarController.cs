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
    public class ClaseAsignarController : Controller
    {

        public IClaseService claseService = new ClaseService();
        public ITokenService tokenService = new TokenService();

        
        public int PostClase(ClaseModel clase)
        {
            var body = Request.Body;
            Token token = new Token();
            return claseService.PostAsignada(clase);
        }

    }
}