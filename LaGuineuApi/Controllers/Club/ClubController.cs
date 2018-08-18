using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class ClubController : Controller
    {

        public IClubService clubService = new ClubService();
        public IUsuarioService usuarioService = new UsuarioService();
        
        // GET: Clubes
        public List<Club> GetClubesEscuela()
        {
            Token token = (Token)Request.Properties["token"];
            return clubService.GetClubesEscuela(token.IdEscuela);
        }

        public Object GetClub(int id)
        {
            return clubService.GetClub(id);
        }

        public int Post(ClubModel club) // List<MonitorTitulo> titulos
        {
            Token token = (Token)Request.Properties["token"];
            club.Club.IdEscuela = token.IdEscuela;
            return clubService.EditarClub(club);
        }

    }
}