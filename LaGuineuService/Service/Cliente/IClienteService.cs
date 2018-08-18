
using LaGuineuData;
using System.Collections.Generic;

namespace LaGuineuService.Services
{ 
    public interface IClienteService
    {
        int PostCliente(ClienteModel escuela);
        Cliente GetCliente(int id);
        List<Cliente> GetClientesEscuela(int idEscuela);
    }
}