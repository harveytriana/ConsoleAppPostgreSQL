using Newtonsoft.Json;
using System;
// it must be a Standard library
// keep herr by example
//
namespace BooksClient
{
    public partial class Book
    {
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("published_date")]
        public DateTime Date { get; set; }

        // ForeignKey
        //public long AuthorId { get; set; }
        //public virtual Author Author { get; set; }
        [JsonProperty("author")]
        public int Author { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }
    // * Change from byte[] to DateTime

    public partial class Author
    {
        public long Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        // no in api
        // public virtual ICollection<Book> Books { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
