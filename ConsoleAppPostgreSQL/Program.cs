using ConsoleAppPostgreSQL.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
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
*/

namespace ConsoleAppPostgreSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Npgsql.EntityFrameworkCore.PostgreSQL!");
            InsertBooks();
        }

        private static void InsertBooks()
        {
            using var db = new BooksDb();

            try {
                if (db.Books.Any() == false) {

                    var authors = new List<Author>
                    {
                        new Author{ AuthorId = 1,  FirstName = "John", LastName = "Lennon" },
                        new Author{ AuthorId = 2,  FirstName = "Frank", LastName = "Zappa" }
                    };

                    var books = new List<Book>()
                    {
                        new Book{ AuthorId = 1,  Title = "In His On Right" },
                        new Book{ AuthorId = 1,  Title = "Yer Blues" },
                        new Book{ AuthorId = 2,  Title = "Led World" },
                    };
                    db.Authors.AddRange(authors);
                    db.Books.AddRange(books);

                    db.SaveChanges();
                }
                foreach (var book in db.Books.ToList())
                    Console.WriteLine(book);
            }
            catch (Exception exception) {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }
    }
}
