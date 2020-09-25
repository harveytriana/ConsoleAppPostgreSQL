using System;
using System.Collections.Generic;

namespace Books
{
    public partial class BooksBook
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public byte[] Date { get; set; }
        public long AuthorId { get; set; }

        public virtual BooksAuthor Author { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }
}
