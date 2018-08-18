using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class EscuelaEstacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdEstacion { get; set; }
        public int IdEscuela { get; set; }
    }
}
