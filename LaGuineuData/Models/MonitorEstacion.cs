using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class MonitorEstacion
    {
        public int Id { get; set; }
        public int IdMonitor { get; set; }
        public int IdEstacion { get; set; }

        public Estacion IdEstacionNavigation { get; set; }
        public Monitor IdMonitorNavigation { get; set; }
    }
}
