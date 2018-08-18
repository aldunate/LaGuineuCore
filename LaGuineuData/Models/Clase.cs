using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Clase
    {
        public Clase()
        {
            ClaseGrupoAlumno = new HashSet<ClaseGrupoAlumno>();
            ClaseMonitor = new HashSet<ClaseMonitor>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdEstacion { get; set; }
        public int IdEscuela { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdCliente { get; set; }
        public int IdGrupo { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Escuela IdEscuelaNavigation { get; set; }
        public Estacion IdEstacionNavigation { get; set; }
        public Grupo IdGrupoNavigation { get; set; }
        public ICollection<ClaseGrupoAlumno> ClaseGrupoAlumno { get; set; }
        public ICollection<ClaseMonitor> ClaseMonitor { get; set; }
    }
}
