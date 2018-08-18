
using LaGuineuData.Models;
using System.Collections.Generic;

namespace LaGuineuService.Services
{ 
    public interface IDeporteService
    {
        List<Deporte> GetDeportes();
        List<Deporte> GetDeportes(int idEscuela);
    }
}