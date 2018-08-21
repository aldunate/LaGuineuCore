using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    public class AuthController : Controller
    {
        ITokenService tokenService = new TokenService();
        IUsuarioService usuarioService = new UsuarioService();


        // Autentificacion devuelve token
        public string Post(Usuario usuario)
        {
            usuario = usuarioService.GetUsuario(usuario.Id);
            var operacion = "Gestion";
            // if (usuario.IdMonitor != null) operacion = "Monitor";
            if(usuario != null) return tokenService.CreateToken(usuario,operacion).Nombre;
            return "El usuario no existe";
        }

    }
}