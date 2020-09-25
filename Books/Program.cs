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

            ReadSample();
        }

        private static void InsertBooks()
        {
            using var db = new BooksContext();
            try {
                if (db.BooksBook.Any() == false) {
                    Console.WriteLine("\nInserting...");
                    var authors = new List<Author>
                    {
                        new Author{ Id = 1,  FirstName = "John", LastName = "Lennon" },
                        new Author{ Id = 2,  FirstName = "Frank", LastName = "Zappa" }
                    };
                    var books = new List<Book>()
                    {
                        new Book{ Id = 1, AuthorId = 1,  Title = "In His On Right", Date = new DateTime(1970, 2, 3) },
                        new Book{ Id = 2, AuthorId = 1,  Title = "Yer Blues", Date = new DateTime(1968, 2, 12) },
                        new Book{ Id = 3, AuthorId = 2,  Title = "Led World", Date = new DateTime(1975, 11, 3) },
                    };

                    db.BooksAuthor.AddRange(authors);
                    db.BooksBook.AddRange(books);
                    db.SaveChanges();
                }
                Console.WriteLine("\nReading...");
                foreach (var book in db.BooksBook.ToList())
                    Console.WriteLine($"{book}, {book.Date:dd-MM-yyyy}");
            }
            catch (Exception exception) {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }

        private static void ReadSample()
        {
            using var db = new BooksContext();
            try {
                var author = db.BooksAuthor.FirstOrDefault(x => x.LastName == "Lennon");
                if (author != null) {
                    Console.WriteLine("\nAuthor = {0}", author.FullName());
                    Console.WriteLine("Books");
                    foreach (var book in author.Books) {
                        Console.WriteLine("    {0} ({1})", book.Title, book.Date.ToShortDateString());
                    }
                }
            }
            catch (Exception exception) {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }
    }
}
