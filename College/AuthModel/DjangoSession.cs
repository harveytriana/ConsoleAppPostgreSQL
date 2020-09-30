using System;
using System.Collections.Generic;

namespace College
{
    public partial class DjangoSession
    {
        public string SessionKey { get; set; }
        public string SessionData { get; set; }
        public byte[] ExpireDate { get; set; }
    }
}
