using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BooksClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Django REST API");

            var rc = new RestClient("http://127.0.0.1:5004");

            Console.WriteLine("\nBOOKS");
            var books = rc.GetAll<Book>("/Books").Result;
            if (books != null)
                foreach (var book in books)
                    Console.WriteLine($"{book}, {book.Date:dd-MM-yyyy}");
            else Console.WriteLine("Books is null");

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

            Console.WriteLine("\nGet(pk)");
            Console.WriteLine(rc.Get<Book>("/Books", 2).Result);

        }

        
    }
}
