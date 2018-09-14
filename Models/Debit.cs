using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public class Debit
    {
        public int id { get; set; }
        public Nullable<int> SuppID { get; set; }
        public Nullable<decimal> DebitAmount { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
