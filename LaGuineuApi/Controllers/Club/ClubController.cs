using System;
using System.Collections.Generic;
using System.Linq;
using LaGuineuData;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class ClubController : Controller
    {

        public IClubService clubService = new ClubService();
        public IUsuarioService usuarioService = new UsuarioService();
        
        // GET: Clubes
        public List<Club> GetClubesEscuela()
        {
            var body = Request.Body;
            Token token = new Token();
            // return clubService.GetClubesEscuela(token.IdEscuela);
            return null;
        }

        public Object GetClub(int id)
        {
            return clubService.GetClub(id);
        }

        public int Post(ClubModel club) // List<MonitorTitulo> titulos
        {
            var body = Request.Body;
            Token token = new Token();
            // club.Club.IdEscuela = token.IdEscuela;
            return clubService.EditarClub(club);
        }

    }
}