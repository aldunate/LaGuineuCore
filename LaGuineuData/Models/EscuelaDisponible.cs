using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class EscuelaDisponible
    {
        public int Id { get; set; }
        public DateTime? FechaEvento { get; set; }
        public int IdEscuela { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        public Escuela IdEscuelaNavigation { get; set; }
    }
}
