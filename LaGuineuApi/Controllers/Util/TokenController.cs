using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
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