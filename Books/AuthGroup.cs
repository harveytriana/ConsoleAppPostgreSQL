using System;
using System.Collections.Generic;

namespace Books
{
    public partial class AuthGroup
    {
        public AuthGroup()
        {
            AuthGroupPermissions = new HashSet<AuthGroupPermissions>();
            AuthUserGroups = new HashSet<AuthUserGroups>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthGroupPermissions> AuthGroupPermissions { get; set; }
        public virtual ICollection<AuthUserGroups> AuthUserGroups { get; set; }
    }
}
