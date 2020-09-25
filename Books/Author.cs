using System;
using System.Collections.Generic;

namespace Books
{
    public partial class Author
    {
        public Author()
        {
            BooksBook = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> BooksBook { get; set; }

        public string Name() => $"{FirstName} {LastName}";

        public override string ToString() => Name();
    }
}
