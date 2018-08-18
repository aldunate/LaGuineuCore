using System;
using System.Collections.Generic;

namespace LaGuineuData
{
    public partial class Insituto
    {
        public Insituto()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
    }
}
