using System;

namespace EscuelaPG
{
    public partial class EscuelaMatricula
    {
        public int Id { get; set; }
        public DateTime FechaMatricula { get; set; }
        public int AlumnoId { get; set; }
        public int CursoId { get; set; }

        public virtual EscuelaAlumno Alumno { get; set; }
        public virtual EscuelaCurso Curso { get; set; }

        public override string ToString() => $"{Alumno} ({Curso})";
    }
}
