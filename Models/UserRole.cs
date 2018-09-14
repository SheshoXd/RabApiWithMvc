using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public partial class UserRole
    {
        public int ID { get; set; }
        public Nullable<int> RID { get; set; }
        public Nullable<int> UID { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
