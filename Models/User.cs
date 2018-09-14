using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public partial class User
    {
        public User()
        {
            this.UserRoles = new List<UserRole>();
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime AddedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string IP { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
