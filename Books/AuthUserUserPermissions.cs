using System;
using System.Collections.Generic;

namespace Books
{
    public partial class AuthUserUserPermissions
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PermissionId { get; set; }

        public virtual AuthPermission Permission { get; set; }
        public virtual AuthUser User { get; set; }
    }
}
