using System.Collections.Generic;
using LaGuineuData;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
public class PostUsuario
{
    public Usuario Usuario { get; set; }
    public string Operacion { get; set; }
}
namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class UsuarioController : Controller
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();
        private ITokenService tokenService = new TokenService();

        public List<UsuarioModel> Get()
        {
            var body = Request.Body;
            Token token = new Token();
            return usuarioService.GetUsuariosEscuela(token.IdEscuela);
        }

        public Usuario Get(int id)
        {
            return usuarioService.GetUsuario(id);
        }

        public ObjectResult Post(PostUsuario pu)
        {
            Usuario usuario = pu.Usuario;
            var body = Request.Body;
            Token token = new Token();
            usuario.IdEscuela = token.IdEscuela;
            return Ok(usuarioService.EditarUsuario(usuario,pu.Operacion));
        }


    }
}