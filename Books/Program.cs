using System;
using System.Collections.Generic;
using System.Linq;
/*
 * Reverse Engineering with ef CLI
 * dotnet ef dbcontext scaffold "Data Source=Books.sqlite3" Microsoft.EntityFrameworkCore.Sqlite
*/

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reverse Engineering for django Database");
            InsertBooks();
        }

        private static void InsertBooks()
        {
            using var db = new BooksContext();
            try {
                if (db.BooksBook.Any() == false) {
                    Console.WriteLine("\nInserting...");
                    var authors = new List<BooksAuthor>
                    {
                        new BooksAuthor{ Id = 1,  FirstName = "John", LastName = "Lennon" },
                        new BooksAuthor{ Id = 2,  FirstName = "Frank", LastName = "Zappa" }
                    };
                    var books = new List<BooksBook>()
                    {
                        new BooksBook{ Id = 1, AuthorId = 1,  Title = "In His On Right" },
                        new BooksBook{ Id = 2, AuthorId = 1,  Title = "Yer Blues" },
                        new BooksBook{ Id = 3, AuthorId = 2,  Title = "Led World" },
                    };

                    db.BooksAuthor.AddRange(authors);
                    db.BooksBook.AddRange(books);

                    db.SaveChanges();
                }
                Console.WriteLine("\nReading...");
                foreach (var book in db.BooksBook.ToList())
                    Console.WriteLine(book);
            }
            catch (Exception exception) {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }
    }
}
