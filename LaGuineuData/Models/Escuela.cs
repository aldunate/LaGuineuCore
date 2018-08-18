using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class Escuela
    {
        public Escuela()
        {
            Clase = new HashSet<Clase>();
            Cliente = new HashSet<Cliente>();
            EscuelaDisponible = new HashSet<EscuelaDisponible>();
            Monitor = new HashSet<Monitor>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string FotoPerfil { get; set; }

        public ICollection<Clase> Clase { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<EscuelaDisponible> EscuelaDisponible { get; set; }
        public ICollection<Monitor> Monitor { get; set; }
    }
}
