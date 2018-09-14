using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            this.PurchaseOrdersDetails = new List<PurchaseOrdersDetail>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderType { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<int> SuppId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> PaymantType { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> Creditor { get; set; }
        public Nullable<int> PostingStats { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseOrdersDetail> PurchaseOrdersDetails { get; set; }
    }
}
