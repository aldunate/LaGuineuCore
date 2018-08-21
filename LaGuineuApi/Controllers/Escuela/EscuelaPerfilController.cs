using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LaGuineuApi.Util.lib;
using LaGuineuData.Models;
using LaGuineuService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class EscuelaPerfilController : Controller
    {
        public IEscuelaService escuelaService = new EscuelaService();

        public HttpResponseMessage GetImagen(string strFileUrl)
        {
            return FileUtil.Download("EscuelaPerfil/" + strFileUrl, "Imagen");
        }
        [HttpPost]
        public HttpResponseMessage Post()
        {
            var httpContextCurrent = HttpContext; //HttpContext.Current;
            // HttpResponseMessage json = FileUtil.Upload(Request, httpContextCurrent, "~/App_Data/Imagenes/EscuelaPerfil");
            /*JObject jObject = JObject.Parse(json.Content.ReadAsStringAsync().Result);
            var fileName = jObject.GetValue("fileName").ToString();

            var body = Request.Body;
            Token token = new Token();
            escuelaService.GuardarPerfil(token.IdEscuela, fileName);
            return json;*/
            return null;
        }
    }
}


