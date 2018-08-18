using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class Token
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCrea { get; set; }
        public int? IdUsuario { get; set; }
        public string IdEscuela { get; set; }
        public string IdMonitor { get; set; }
    }
}
