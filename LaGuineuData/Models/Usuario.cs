using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Monitor = new HashSet<Monitor>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdInfo { get; set; }
        public int IdEscuela { get; set; }
        public int IdPermisos { get; set; }
        public sbyte Activado { get; set; }

        public ICollection<Monitor> Monitor { get; set; }
    }
}
