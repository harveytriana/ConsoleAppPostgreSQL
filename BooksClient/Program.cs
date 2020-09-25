using System;

namespace BooksClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("API TEST");

            var rc = new RestClient("http://127.0.0.1:5004");

            Console.WriteLine("\nBOOKS");
            var books = rc.GetAll<Book>("/Books").Result;
            if (books != null)
                foreach (var book in books)
                    Console.WriteLine($"{book}, {book.Date:dd-MM-yyyy}");
            else Console.WriteLine("Books is null");

            Console.WriteLine("\nAUTHORS");
            var authors = rc.GetAll<Author>("/Authors").Result;
            if (authors != null)
                foreach (var author in authors)
                    Console.WriteLine($"{author.Id}: {author}");
            else Console.WriteLine("Authors is null");
        }
    }
}
