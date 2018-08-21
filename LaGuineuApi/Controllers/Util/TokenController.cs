using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    public class TokenController : Controller
    {
        // Curso
        private IUtilService utilService = new UtilService();
        private ITokenService tokenService = new TokenService();

        public bool GetToken()
        {
            return true;
        }



    }
}