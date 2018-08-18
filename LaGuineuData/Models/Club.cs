using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Club
    {
        public Club()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int IdClub { get; set; }
        public string Nombre { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
    }
}
