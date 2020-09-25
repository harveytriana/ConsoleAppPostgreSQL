using System.Collections.Generic;

namespace ConsoleAppPostgreSQL.Model
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public string Name() => $"{FirstName} {LastName}";

        public override string ToString() => Name();
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }
}
