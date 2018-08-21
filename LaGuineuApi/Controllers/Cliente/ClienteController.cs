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

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]"), EnableCors("MyPolicy")]
    [Authorize]
    public class ClienteController : Controller
    {

        public IClienteService clienteService = new ClienteService();
        public IUsuarioService usuarioService = new UsuarioService();
        
        // GET: Monitor
        public Object GetCliente(int id)
        {
            return clienteService.GetCliente(id);
        }

        public Object GetClientesEscuela()
        {
            var body = Request.Body;
            Token token = new Token();
            return clienteService.GetClientesEscuela(token.IdEscuela);
        }

        public int Post(ClienteModel cliente)
        {
            var body = Request.Body;
            Token token = new Token();
            cliente.Cliente.IdEscuela = token.IdEscuela;
            cliente.Usuario.IdEscuela = token.IdEscuela;
            return clienteService.PostCliente(cliente);
        }


    }
}