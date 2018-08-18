﻿
using LaGuineuData;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
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
            Token token = (Token) Request.Properties["token"];
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
            Token token = (Token)Request.Properties["token"];
            clase.Clase.IdEscuela = token.IdEscuela;
            return claseService.PostClase(clase).Id;
        }

    }
}