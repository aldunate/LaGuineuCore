
using LaGuineuData.Models;
using System.Collections.Generic;

namespace LaGuineuData
{
    public class ClaseModel
    {
        public Clase Clase { get; set; }
        public List<ClaseMonitor> Monitores { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Operacion { get; set; }
    }
    
}