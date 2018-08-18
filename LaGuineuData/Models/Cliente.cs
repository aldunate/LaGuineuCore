using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Clase = new HashSet<Clase>();
            Grupo = new HashSet<Grupo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdClub { get; set; }
        public int? IdInstituto { get; set; }
        public int IdEscuela { get; set; }

        public Club IdClubNavigation { get; set; }
        public Escuela IdEscuelaNavigation { get; set; }
        public Insituto IdInstitutoNavigation { get; set; }
        public ICollection<Clase> Clase { get; set; }
        public ICollection<Grupo> Grupo { get; set; }
    }
}
