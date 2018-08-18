using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Titulo
    {
        public Titulo()
        {
            MonitorTitulo = new HashSet<MonitorTitulo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<MonitorTitulo> MonitorTitulo { get; set; }
    }
}
