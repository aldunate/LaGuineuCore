using System;
using System.Collections.Generic;
// ReSharper disable All

namespace LaGuineuData.Models
{
    public partial class Alumno
    {
        public Alumno() => ClaseGrupoAlumno = new HashSet<ClaseGrupoAlumno>();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdNivel { get; set; }
        public int IdGrupo { get; set; }

        public Grupo IdGrupoNavigation { get; set; }
        public ICollection<ClaseGrupoAlumno> ClaseGrupoAlumno { get; set; }
    }
}
