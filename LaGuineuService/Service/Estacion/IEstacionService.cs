
using LaGuineuData.Models;
using System.Collections.Generic;

namespace LaGuineuService.Services
{ 
    public interface IEstacionService
    {
        List<Estacion> GetEstaciones();
        List<EscuelaEstacion> GetEstacionEscuela(int idEscuela);
    }
}