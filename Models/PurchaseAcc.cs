using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public partial class PurchaseAcc
    {
        public int PurAccId { get; set; }
        public string PurAccDisc { get; set; }
        public Nullable<decimal> PurAddDebet { get; set; }
        public Nullable<decimal> PurAccCreadit { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }
}
