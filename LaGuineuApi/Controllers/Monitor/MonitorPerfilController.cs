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

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class MonitorPerfilController : Controller
    {
        public IMonitorService monitorService = new MonitorService();
 
        public HttpResponseMessage Get(string strFileUrl)
        {
            return FileUtil.Download("MonitorPerfil/" + strFileUrl, "Imagen");
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync()
        {
            /* HttpResponseMessage json = await FileUtil.Upload(Request,HttpContext.Current, "~/App_Data/Imagenes/MonitorPerfil");
             JObject jObject = JObject.Parse(json.Content.ReadAsStringAsync().Result);
             var fileName = jObject.GetValue("fileName").ToString();
             var idMonitor = int.Parse(jObject.GetValue("idMonitor").ToString());
             monitorService.GuardarPerfil(idMonitor, fileName);
             return json;*/
            return null;

        }
    }
}


