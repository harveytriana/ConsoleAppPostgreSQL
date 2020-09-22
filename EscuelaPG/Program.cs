using System;
using System.Linq;
/*
dotnet ef dbcontext scaffold "Host=my_host;Database=my_db;Username=my_user;Password=my_pw" Npgsql.EntityFrameworkCore.PostgreSQL
 */

namespace EscuelaPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello PostgreSql!");

            Console.WriteLine("\nREADING");

            using var db = new LabsContext();

            Console.WriteLine("\nALUMNOS");
            var alumnos = db.EscuelaAlumno.ToList();
            foreach (var i in alumnos)
                Console.WriteLine(i);

            Console.WriteLine("\nCURSOS");
            var cursos = db.EscuelaCurso.ToList();
            foreach (var i in cursos)
                Console.WriteLine(i);

            Console.WriteLine("\nMATRICULAS");
            var matriculas = db.EscuelaMatricula.ToList();
            foreach (var i in matriculas)
                Console.WriteLine($"Matricula: {i}");

        }
    }
}
