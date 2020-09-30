using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Linq;
/*
 * DJANGO STRUCTURE 
 * dotnet ef dbcontext scaffold "Host=my_host;Database=my_db;Username=my_user;Password=my_pw" Npgsql.EntityFrameworkCore.PostgreSQL
 * dotnet ef dbcontext scaffold "Data Source=C:\_study\Python\LABS-django\college.sqlite3" Microsoft.EntityFrameworkCore.Sqlite
 */
namespace College
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reengineering a Django database");

            TestDb();
        }

        private static void TestDb()
        {
            using var db = new CollegeContext();
            try {
                Console.WriteLine("\nReading...");
                //! NOTE 1
                // Does need UseLazyLoadingProxies() 
                // i.e. Microsoft.EntityFrameworkCore.Proxies
                // 
                var students = db.CollegeStudent
                    .Include(x => x.CollegeEnrollment)
                    .ThenInclude(y => y.AcademicCourse)
                    .ToList();

                foreach (var student in students) {
                    Console.WriteLine(student);
                    foreach (var enrollment in student.CollegeEnrollment) {
                        Console.WriteLine($"  {enrollment.AcademicCourse}");
                    }
                }
            }

            catch (Exception exception) {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }
    }
}
