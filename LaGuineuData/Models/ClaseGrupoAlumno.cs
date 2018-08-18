using System;
using System.Collections.Generic;

namespace LaGuineuData.Models
{
    public partial class ClaseGrupoAlumno
    {
        public int Id { get; set; }
        public int IdClase { get; set; }
        public int IdAlumno { get; set; }

        public Alumno IdAlumnoNavigation { get; set; }
        public Clase IdClaseNavigation { get; set; }
    }
}
