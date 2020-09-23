using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPostgreSQL.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            return $"{Title}, {Author.Name()} ";
        }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public string Name() => $"{FirstName} {LastName}";
    }
}
