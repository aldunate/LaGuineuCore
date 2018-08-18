using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class RegistroController : Controller
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();

        public Usuario Get(string nombre)
        {
            return usuarioService.GetUsuario(nombre);
        }

    }
}