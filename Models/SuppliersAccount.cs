using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class SuppliersAccount
    {
        public int SuppAccId { get; set; }
        public Nullable<int> SuppId { get; set; }
        public Nullable<decimal> SuppCreditor { get; set; }
        public Nullable<decimal> SuppDebit { get; set; }
        public Nullable<int> AccType { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
