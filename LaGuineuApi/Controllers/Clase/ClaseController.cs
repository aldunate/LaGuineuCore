
using LaGuineuData;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class ClaseController : Controller
    {

        public IClaseService claseService = new ClaseService();
        public ITokenService tokenService = new TokenService();

        // GET: Monitor
        public Object Get(int id)
        {
            return claseService.GetClase(id);
        }

        // GET: Monitor
        public Boolean Delete(int idClase)
        {
            return claseService.DeleteClase(idClase);
        }

        public Object GetClases(string operacion,string fecha)
        {
            var body = Request.Body;
            Token token = new Token();
            if(operacion == "Todas")
            {
                return claseService.GetClaseEscuela(token.IdEscuela);

            }
            if (operacion == "Fecha")
            {
                return claseService.GetClaseEscuelaFecha(token.IdEscuela,fecha);

            }
            return null;

        }

        public int PostClase(ClaseModel clase)
        {
            var body = Request.Body;
            Token token = new Token();
            clase.Clase.IdEscuela = token.IdEscuela;
            return claseService.PostClase(clase).Id;
        }

    }
}