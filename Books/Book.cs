﻿using System;
using System.Collections.Generic;

namespace Books
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        // *
        public DateTime Date { get; set; }
        // ForeignKey
        public long AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }
    // * Change from byte[] to DateTime

    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public string FullName() => $"{FirstName} {LastName}";

        public override string ToString() => FullName();
    }
}
