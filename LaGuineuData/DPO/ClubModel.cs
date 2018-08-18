using LaGuineuData.Models;
using System.Collections.Generic;

namespace LaGuineuData
{
    public class ClubModel
    {
        public Club Club { get; set; }
        public List<Cliente> Clientes { get; set; }
        public string Operacion { get; set; }
    }
}