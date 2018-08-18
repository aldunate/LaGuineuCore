using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
public class PostEscuela
{
    public Escuela Escuela { get; set; }
    public Usuario Usuario { get; set; }
}
namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class DeporteController : Controller
    {

        public IEscuelaService escuelaService = new EscuelaService();
        public IUsuarioService usuarioService = new UsuarioService();

        public EscuelaModel GetEscuela()
        {
            Token token = (Token)Request.Properties["token"];
            return escuelaService.GetEscuela(token.IdEscuela);
        }

        public EscuelaModel Post(EscuelaModel escuela) // List<MonitorTitulo> titulos
        {
            Token token = (Token)Request.Properties["token"];
            if(escuela.Escuela == null)
            {
                escuela.Escuela = new Escuela();
                escuela.Escuela.Id = token.IdEscuela;
            }
            return escuelaService.EditarEscuela(escuela);
        }
    }
}