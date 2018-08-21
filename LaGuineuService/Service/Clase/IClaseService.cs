﻿
using LaGuineuData;
using LaGuineuData.Models;
using System.Collections.Generic;

namespace LaGuineuService.Services
{
    public interface IClaseService
    {
        Clase GetClase(int id);
        List<Clase> GetClaseEscuela(int idEscuela);
        List<ClaseModel> GetClaseEscuelaFecha(int idEscuela, string fecha);
        int PostAsignada(ClaseModel clase);
        Clase PostClase(ClaseModel clase);
        bool DeleteClase(int idClase);
    }
}