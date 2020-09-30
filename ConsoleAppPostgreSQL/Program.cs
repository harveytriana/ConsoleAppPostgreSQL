using ConsoleAppPostgreSQL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
/*
Entity Framework Core tools reference - Package Manager Console in Visual Studio
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell

Npgsql.EntityFrameworkCore.PostgreSQL
https://www.npgsql.org/efcore/

dotnet-ef war
-------------
Visual Studio
https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli
General
https://docs.microsoft.com/es-es/ef/core/miscellaneous/cli/dotnet
https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli
dotnet tool install --global dotnet-ef
dotnet*ef has to run as Administrator

RESUME
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

NOTE
It was rwmoved * for use Include
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="3.1.4" />

*/

namespace ConsoleAppPostgreSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BOOKS COLLECTION");
            Console.WriteLine("Practice on EF and Npgsql.EntityFrameworkCore.PostgreSQL");
            Console.WriteLine("No related a Django database\n");
            Seedooks();
        }

        private static void Seedooks()
        {
            using var db = new BooksDb();
            try {
                if (db.Books.Any() == false) {
                    Console.WriteLine("\nInserting...");
                    var authors = new List<Author>
                    {
                        new Author{ AuthorId = 1,  FirstName = "John", LastName = "Lennon" },
                        new Author{ AuthorId = 2,  FirstName = "Frank", LastName = "Zappa" }
                    };
                    var books = new List<Book>()
                    {
                        new Book{ BookId = 1, AuthorId = 1,  Title = "In His On Right" },
                        new Book{ BookId = 2, AuthorId = 1,  Title = "Yer Blues" },
                        new Book{ BookId = 3, AuthorId = 2,  Title = "Led World" },
                    }; 
                    db.Authors.AddRange(authors);
                    db.Books.AddRange(books);
                    db.SaveChanges();
                }
               
            }
            catch (Exception exception) {
                Console.WriteLine($"Exception: {exception.Message}");
                return;
            }

            Console.WriteLine("\nREADING");
            foreach (var book in db.Books.Include(x => x.Author).ToList())
                Console.WriteLine(book);
        }
    }
}
