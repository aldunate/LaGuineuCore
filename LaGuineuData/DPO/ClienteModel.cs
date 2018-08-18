
using LaGuineuData.Models;

namespace LaGuineuData
{
    public class ClienteModel
    {
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public string Operacion { get; set; }
    }
}