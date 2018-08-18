using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Estacion
    {
        public Estacion()
        {
            Clase = new HashSet<Clase>();
            MonitorEstacion = new HashSet<MonitorEstacion>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public int IdDefecto { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public ICollection<Clase> Clase { get; set; }
        public ICollection<MonitorEstacion> MonitorEstacion { get; set; }
    }
}
