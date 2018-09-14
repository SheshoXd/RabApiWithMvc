using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class ClientAccount
    {
        public int ClntAccId { get; set; }
        public Nullable<int> ClntId { get; set; }
        public Nullable<decimal> ClntDebit { get; set; }
        public Nullable<decimal> ClntCreditor { get; set; }
        public Nullable<decimal> ClntBalance { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string MoveType { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual Client Client { get; set; }
    }
}
