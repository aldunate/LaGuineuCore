using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
public class PostUsuario
{
    public Usuario Usuario { get; set; }
    public string Operacion { get; set; }
}
namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();
        private ITokenService tokenService = new TokenService();

        public List<UsuarioModel> Get()
        {
            Token token = (Token) Request.Properties["token"];
            return usuarioService.GetUsuariosEscuela(token.IdEscuela);
        }

        public Usuario Get(int id)
        {
            return usuarioService.GetUsuario(id);
        }

        public IHttpActionResult Post(PostUsuario pu)
        {
            Usuario usuario = pu.Usuario;
            Token token = (Token)Request.Properties["token"];
            usuario.IdEscuela = token.IdEscuela;
            return Ok(usuarioService.EditarUsuario(usuario,pu.Operacion));
        }


    }
}