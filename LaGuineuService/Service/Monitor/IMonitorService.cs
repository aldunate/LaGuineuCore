using LaGuineuData;
using LaGuineuData.Models;
using System;
using System.Collections.Generic;

namespace LaGuineuService.Services
{
    public interface IMonitorService
    {
        MonitorModel GetMonitor(int id);
        MonitorModel EditarMonitor(MonitorModel monitor);
        List<Monitor> GetMonitorEscuela(int idEscuela);
        int GuardarPerfil(int idMonitor, string fotoPerfil);
        List<Clase> GetClasesMonitorFecha(DateTime fecha, int idMonitor);
    }
}