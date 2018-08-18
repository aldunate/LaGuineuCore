using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class MonitorTitulo
    {
        public int Id { get; set; }
        public int IdTitulo { get; set; }
        public int IdMonitor { get; set; }

        public Monitor IdMonitorNavigation { get; set; }
        public Titulo IdTituloNavigation { get; set; }
    }
}
