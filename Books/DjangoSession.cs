using System;
using System.Collections.Generic;

namespace Books
{
    public partial class DjangoSession
    {
        public string SessionKey { get; set; }
        public string SessionData { get; set; }
        public byte[] ExpireDate { get; set; }
    }
}
