
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    public class LoginController : Controller
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();

        [HttpPost]
        public ObjectResult Post([FromBody]Usuario usuario)
        {
            return Ok(usuarioService.LoginUsuario(usuario));
        }


    }
}