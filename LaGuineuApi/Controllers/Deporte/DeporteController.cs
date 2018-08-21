using System;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

public class PlayerRequest
{
    public string PerMode { get; set; }
    public string LeagueID { get; set; }
    public string Season { get; set; }
    public string SeasonType { get; set; }
}

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class DeporteController : Controller
    {

        public IDeporteService deporteService = new DeporteService();
        
        // GET: Monitor
        public Object GetDeportes()
        {
            return deporteService.GetDeportes();
        }
       

        public Object GetDeportes(int idEscuela)
        {
            return deporteService.GetDeportes(idEscuela);
        }


        /*
        public async Task<Object> GetPrueba(string perMode, string leagueId, string season, string seasonType)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("accept-encoding", "Accepflate, sdch");
                client.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");
                client.DefaultRequestHeaders.TryAddWithoutValidation("origin", "http://stats.nba.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("http://stats.nba.com/stats/leaguedashplayerbiostats?PerMode=Totals&LeagueID=00&Season=2016-17&SeasonType=Regular+Season");
                return await response.Content.ReadAsAsync<Object>();
            }
            catch(Exception e)
            {
                return e;
            }
        }
        */
    }
}