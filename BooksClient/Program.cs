using System;

namespace BooksClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("API TEST");

            var rc = new RestClient<Book>("http://127.0.0.1:5004/Books/");

            var books = rc.GetAll().Result;

            Console.WriteLine("\nReading...");
            if (books != null)
                foreach (var book in books)
                    Console.WriteLine($"{book}, {book.Date:dd-MM-yyyy}");
            else Console.WriteLine("Books is null");
        }
    }
}
