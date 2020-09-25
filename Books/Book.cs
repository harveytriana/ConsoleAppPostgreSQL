using System;
using System.Collections.Generic;

namespace Books
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        // *
        public DateTime Date { get; set; }
        public long AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }

    // * Change from byte[] to DateTime
}
