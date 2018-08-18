using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaGuineuApiCore.Controllers
{
    [Route("api/[controller]")]
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
            Token token = (Token)Request.Properties["token"];
            return clienteService.GetClientesEscuela(token.IdEscuela);
        }

        public int Post(ClienteModel cliente)
        {
            Token token = (Token)Request.Properties["token"];
            cliente.Cliente.IdEscuela = token.IdEscuela;
            cliente.Usuario.IdEscuela = token.IdEscuela;
            return clienteService.PostCliente(cliente);
        }


    }
}