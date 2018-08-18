using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class GrupoMonitorPlantilla
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdMonitor { get; set; }

        public Grupo IdGrupoNavigation { get; set; }
        public Monitor IdMonitorNavigation { get; set; }
    }
}
