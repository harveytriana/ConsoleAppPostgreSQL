using System;
using System.Collections.Generic;

namespace EscuelaPG
{
    public partial class EscuelaCurso
    {
        public EscuelaCurso()
        {
            EscuelaMatricula = new HashSet<EscuelaMatricula>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public short Creditos { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<EscuelaMatricula> EscuelaMatricula { get; set; }

        public override string ToString() => $"{Nombre} ({Creditos})";
    }
}
