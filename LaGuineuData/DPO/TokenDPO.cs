using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using LaGuineuData.Models;

namespace LaGuineuData.DPO
{

    [DataContract(Name = "TokenDpo", Namespace = "http://example.org/resources")]
    public sealed class TokenDpo
    {
        // Constructors
        public TokenDpo()
        {
        }

        public TokenDpo(Token token)
        {
            Id = token.Id;
            Nombre = token.Nombre;
            FechaCrea = token.FechaCrea;
            IdUsuario = token.IdUsuario;
            IdEscuela = token.IdEscuela;
            IdMonitor = token.IdMonitor;
        }

        public TokenDpo(int id, string nombre, DateTime? fechaCrea, int idUsuario, int idEscuela, int idMonitor)
        {
            Id = id;
            Nombre = nombre;
            FechaCrea = fechaCrea;
            IdUsuario = idUsuario;
            IdEscuela = idEscuela;
            IdMonitor = idMonitor;
        }

        // Public properties
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime? FechaCrea { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdEscuela { get; set; }
        [DataMember]
        public int IdMonitor { get; set; }

    }
}
