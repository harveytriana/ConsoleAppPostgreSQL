using System;

namespace CollegeClient
{
    class Program
    {
        static RestClient _restClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Client of Django REST API\n");

            _restClient = new RestClient("http://127.0.0.1:5000/");

            GetRandomBook();

            // GetTitles();

            // GetBook();

            // CreateBook();

            UpdateBook();

            // DeleteBook();

            //! important
            _restClient.Dispose();
        }

        private static void DeleteBook()
        {
            Console.WriteLine("DELETE BOOK 101");
            var deleted = _restClient.Delete("api/books", 101).Result;

            Console.WriteLine($"Deleted: {deleted}");
        }

        private static void CreateBook()
        {
            Console.WriteLine("\nCREATE BOOK");
            var book = new Book
            {
                //Author = "John Lennon",
                //ISBN = "0-684-86807-5",
                //ImageLink = "https://bit.ly/2SIQALg",
                //Title = "In his On Right",
                //Language = "English",
                //Link = "https://bit.ly/3nzBjuf",
                //Pages = 200,
                //Year = 1964
                Author = "Hunter Davis",
                Year = 2012,
                ISBN = "0-684-86807-7",
                Language = "English",
                Pages = 123,
                Title = "The John Lennon Letters",
                ImageLink = "https://bit.ly/3ntrmhU",
                Link = "http://www.beatlesradio.com/book-review-the-john-lennon-letters-by-hunter-davies",
            };
            var n = _restClient.Post("api/books/", book).Result;
            if (n != null) {
                Console.WriteLine($"Created, id = {n.Id}");
            }
        }

        private static void UpdateBook()
        {
            Console.WriteLine("PUT BOOK");
            // already exists
            var pk = 106;
            var book = new Book
            {
                // Id = 102,
                Author = "Hunter Davis",
                Year = 2012,
                ISBN = "0-684-86807-7",
                Language = "English",
                Pages = 321,
                Title = "The John Lennon Letters",
                ImageLink = "https://bit.ly/3ntrmhU",
                Link = "http://www.beatlesradio.com/book-review-the-john-lennon-letters-by-hunter-davies",
            };
            var updated = _restClient.Put("api/books", book, pk).Result;

            Console.WriteLine($"Updated {pk}: {updated}");
        }

        // not use 'college' due to the api routed as ViewSet
        private static void GetBook()
        {
            Console.WriteLine("GET BOOK");
            var id = 7;
            var book = _restClient.Get<Book>("api/books", id).Result;
            if (book != null)
                Console.WriteLine($"{book}");
            else
                Console.WriteLine($"Book {id} does not exist.");
        }

        // note the use generic of GetAll, and use college in route
        private static void GetTitles()
        {
            Console.WriteLine("BOOK TITLES");
            var list = _restClient.GetAll<string>("college/api/booktitles").Result;
            if (list != null)
                foreach (var s in list)
                    Console.WriteLine(s);
            else 
                Console.WriteLine("None.");
        }

        // note that use college in route
        private static void GetRandomBook()
        {
            Console.WriteLine("RANDOM BOOK");
            var randomBook = _restClient.GetRandomObject<Book>("college/api/something").Result;
            if (randomBook != null)
                Console.WriteLine($"{randomBook.Id}; {randomBook}");
            else
                Console.WriteLine("Return null.");
        }
    }
}
