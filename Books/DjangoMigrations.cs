using System;
using System.Collections.Generic;

namespace Books
{
    public partial class DjangoMigrations
    {
        public long Id { get; set; }
        public string App { get; set; }
        public string Name { get; set; }
        public byte[] Applied { get; set; }
    }
}
