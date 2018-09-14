using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public partial class Role
    {
        public Role()
        {
            this.RolePermissions = new List<RolePermission>();
            this.UserRoles = new List<UserRole>();
        }

        public int ID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescribe { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
