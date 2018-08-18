using LaGuineuData.Models;
using System.Collections.Generic;

namespace LaGuineuData
{
    public class MonitorModel
    {
        public Monitor Monitor { get; set; }
        public List<MonitorDisponible> FechasDisponibles { get; set; }
        public List<MonitorEstacion> EstacionesDisponibles { get; set; }
        public List<MonitorTitulo> Titulos { get; set; }
        public Usuario Usuario { get; set; }
        public string Operacion { get; set; }
    }
}