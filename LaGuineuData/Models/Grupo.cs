using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Alumno = new HashSet<Alumno>();
            Clase = new HashSet<Clase>();
            GrupoMonitorPlantilla = new HashSet<GrupoMonitorPlantilla>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdNivel { get; set; }
        public int IdCliente { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public ICollection<Alumno> Alumno { get; set; }
        public ICollection<Clase> Clase { get; set; }
        public ICollection<GrupoMonitorPlantilla> GrupoMonitorPlantilla { get; set; }
    }
}
