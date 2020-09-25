using System;
using System.Collections.Generic;

namespace Books
{
    public partial class AuthGroupPermissions
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long PermissionId { get; set; }

        public virtual AuthGroup Group { get; set; }
        public virtual AuthPermission Permission { get; set; }
    }
}
