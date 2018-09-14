using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public partial class RolePermission
    {
        public int ID { get; set; }
        public Nullable<int> RID { get; set; }
        public string PermissionsName { get; set; }
        public Nullable<bool> ReadPermissions { get; set; }
        public Nullable<bool> WritePermissions { get; set; }
        public Nullable<bool> DeletePermissions { get; set; }
        public Nullable<bool> FullPermissions { get; set; }
        public string KeyPermissions { get; set; }
        public virtual Role Role { get; set; }
    }
}
