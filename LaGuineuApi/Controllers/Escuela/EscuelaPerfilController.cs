using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
    public class EscuelaPerfilController : Controller
    {
        public IEscuelaService escuelaService = new EscuelaService();

        public HttpResponseMessage GetImagen(string strFileUrl)
        {
            return FileUtil.Download("EscuelaPerfil/" + strFileUrl, "Imagen");
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync()
        {
            HttpResponseMessage json = await FileUtil.Upload(Request, HttpContext.Current, "~/App_Data/Imagenes/EscuelaPerfil");
            JObject jObject = JObject.Parse(json.Content.ReadAsStringAsync().Result);
            var fileName = jObject.GetValue("fileName").ToString();
            Token token = (Token)Request.Properties["token"];
            escuelaService.GuardarPerfil(token.IdEscuela, fileName);
            return json;
        }
    }
}


