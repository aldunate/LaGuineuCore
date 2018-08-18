using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class ClaseMonitor
    {
        public int Id { get; set; }
        public int IdClase { get; set; }
        public int IdMonitor { get; set; }

        public Clase IdClaseNavigation { get; set; }
        public Monitor IdMonitorNavigation { get; set; }
    }
}
