using System;
using System.Collections.Generic;

namespace Books
{
    public partial class BooksAuthor
    {
        public BooksAuthor()
        {
            BooksBook = new HashSet<BooksBook>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<BooksBook> BooksBook { get; set; }

        public string Name() => $"{FirstName} {LastName}";

        public override string ToString() => Name();
    }
}
