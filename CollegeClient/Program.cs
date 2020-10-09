using System;

namespace CollegeClient
{
    class Program
    {
        static RestClient rc;

        static void Main(string[] args)
        {
            Console.WriteLine("Client of Django REST API");

            rc = new RestClient("http://127.0.0.1:5000/");

            // GetRandomBook();

            // GetTitles();

            // GetBook();

            PostBook();

        }

        private static void PostBook()
        {
            Console.WriteLine("\nPOST BOOK");
            var book = new Book
            {
                Author = "John Lennon",
                ISBN = "0-684-86807-5",
                ImageLink = "https://bit.ly/2SIQALg",
                Title = "In his On Right",
                Language = "English",
                Link = "https://bit.ly/3nzBjuf",
                Pages = 200,
                Year = 1964
            };
            var n = rc.Post("api/books/", book).Result;
            Console.WriteLine($"{n}, id = {n?.Id}");
        }

        // not use 'college' due to the api routed as ViewSet
        private static void GetBook()
        {
            Console.WriteLine("\nBOOK 7");
            var book = rc.Get<Book>("api/books", 7).Result;
            if (book != null)
                Console.WriteLine($"{book}");
            else
                Console.WriteLine("Return null.");
        }

        // note the use generic of GetAll
        private static void GetTitles()
        {
            Console.WriteLine("\nBook Titles");
            var list = rc.GetAll<string>("college/api/booktitles").Result;
            if (list != null)
                foreach (var s in list)
                    Console.WriteLine(s);
            else 
                Console.WriteLine("return null.");
        }

        private static void GetRandomBook()
        {
            Console.WriteLine("\nRANDOM BOOK");
            var randomBook = rc.GetRandomObject<Book>("college/api/something").Result;
            if (randomBook != null)
                Console.WriteLine($"{randomBook}");
            else
                Console.WriteLine("Return null.");

        }
    }
}
