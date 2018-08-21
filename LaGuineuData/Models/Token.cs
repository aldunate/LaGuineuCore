using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Token
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCrea { get; set; }
        public int IdUsuario { get; set; }
        public int IdEscuela { get; set; }
        public int IdMonitor { get; set; }
    }
}
