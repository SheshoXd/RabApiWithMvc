using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public partial class UserProfile
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public System.DateTime AddedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string IP { get; set; }
        public virtual User User { get; set; }
    }
}
