using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
public class PostEscuela
{
    public Escuela Escuela { get; set; }
    public Usuario Usuario { get; set; }
}
namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class EscuelaController : Controller
    {

        public IEscuelaService escuelaService = new EscuelaService();
        public IUsuarioService usuarioService = new UsuarioService();

        [HttpGet]
        public EscuelaModel GetEscuela()
        {
            var body = Request.Body;
            Token token = new Token();
            return escuelaService.GetEscuela(token.IdEscuela);
        }


        public EscuelaModel Post(EscuelaModel escuela) // List<MonitorTitulo> titulos
        {
            var body = Request.Body;
            Token token = new Token();
            if (escuela.Escuela == null)
            {
                escuela.Escuela = new Escuela();
                escuela.Escuela.Id = token.IdEscuela;
            }
            return escuelaService.EditarEscuela(escuela);
        }
    }
}