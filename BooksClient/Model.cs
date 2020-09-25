using System;
using System.Collections.Generic;

// it must be a Standard library
// keep herr by example
//
namespace BooksClient
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        // *
        public DateTime Date { get; set; }

        // ForeignKey
        //public long AuthorId { get; set; }
        //public virtual Author Author { get; set; }
        public int Author { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }
    // * Change from byte[] to DateTime

    public partial class Author
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // no in api
        // public virtual ICollection<Book> Books { get; set; }

        public string FullName() => $"{FirstName} {LastName}";

        public override string ToString() => FullName();
    }
}
