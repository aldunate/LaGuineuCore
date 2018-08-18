using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class MonitorDisponible
    {
        public int Id { get; set; }
        public int IdMonitor { get; set; }
        public DateTime? FechaEvento { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        public Monitor IdMonitorNavigation { get; set; }
    }
}
