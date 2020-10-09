using System;

namespace CollegeClient
{
    class Program
    {
        static RestClient rc;

        static void Main(string[] args)
        {
            Console.WriteLine("Django REST API");

            rc = new RestClient("http://127.0.0.1:5000");

            GetRandomBook();

            //Console.WriteLine("\nBOOKS");
            //var books = rc.GetAll<Book>("/books").Result;
            //if (books != null)
            //    foreach (var book in books)
            //        Console.WriteLine($"{book}");
            //else Console.WriteLine("Books is null");

            //Console.WriteLine("\nAUTHORS");
            //var authors = rc.GetAll<Author>("/Authors").Result;
            //if (authors != null)
            //    foreach (var author in authors)
            //        Console.WriteLine($"{author.Id}: {author}");
            //else Console.WriteLine("Authors is null");

            //Console.WriteLine("\nBook Titles");
            //var list = rc.GetAll<string>("/api/booktitles").Result;
            //if (list != null)
            //    foreach (var s in list)
            //        Console.WriteLine(s);
            //else Console.WriteLine("Authors is null");

            //Console.WriteLine(rc.Get2<Book>().Result);

            //Console.WriteLine(rc.Get3().Result);

            //Console.WriteLine("\nGet(pk)");
            //Console.WriteLine(rc.Get<Book>("/Books", 2).Result);

            // POST
            //Console.WriteLine("\nPost");
            //var i = new Book
            //{
            //    Author = 5,
            //    Date = new DateTime(1980, 1, 12),
            //    Title = "Calculus II"
            //};
            //var n = rc.Post("/Books/", i).Result;
            //Console.WriteLine($"{n}, id = {n?.Id}");

        }

        private static void GetRandomBook()
        {
            Console.WriteLine("\nRANDOM BOOK");
            var randomBook = rc.GetSomething<Book>("/college/api/something").Result;
            if (randomBook != null)
                Console.WriteLine($"{randomBook}");
            else
                Console.WriteLine("Return null.");

        }
    }
}
