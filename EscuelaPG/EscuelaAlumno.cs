using System;
using System.Collections.Generic;

namespace EscuelaPG
{
    public partial class EscuelaAlumno
    {
        public EscuelaAlumno()
        {
            EscuelaMatricula = new HashSet<EscuelaMatricula>();
        }

        public int Id { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<EscuelaMatricula> EscuelaMatricula { get; set; }

        public override string ToString() => $"{Nombres} {ApellidoPaterno}";
    }
}
