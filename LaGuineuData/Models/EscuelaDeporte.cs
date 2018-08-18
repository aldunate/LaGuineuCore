using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class EscuelaDeporte
    {
        public int Id { get; set; }
        public int? IdDeporte { get; set; }
        public int? IdEscuela { get; set; }
    }
}
