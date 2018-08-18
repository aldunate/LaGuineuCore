using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class Monitor
    {
        public Monitor()
        {
            ClaseMonitor = new HashSet<ClaseMonitor>();
            GrupoMonitorPlantilla = new HashSet<GrupoMonitorPlantilla>();
            MonitorDisponible = new HashSet<MonitorDisponible>();
            MonitorEstacion = new HashSet<MonitorEstacion>();
            MonitorTitulo = new HashSet<MonitorTitulo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string FotoPerfil { get; set; }
        public string Telefono { get; set; }
        public int IdInfo { get; set; }
        public int IdUsuario { get; set; }
        public int IdEscuela { get; set; }

        public Escuela IdEscuelaNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<ClaseMonitor> ClaseMonitor { get; set; }
        public ICollection<GrupoMonitorPlantilla> GrupoMonitorPlantilla { get; set; }
        public ICollection<MonitorDisponible> MonitorDisponible { get; set; }
        public ICollection<MonitorEstacion> MonitorEstacion { get; set; }
        public ICollection<MonitorTitulo> MonitorTitulo { get; set; }
    }
}
