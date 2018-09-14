using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class PurchaseOrdersDetail
    {
        public int OrderDitId { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderType { get; set; }
        public Nullable<decimal> QtyReq { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> itemId { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<int> CaseNumber { get; set; }
        public Nullable<decimal> CaseWight { get; set; }
        public Nullable<int> PostingStatus { get; set; }
        public Nullable<decimal> StoredQty { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<decimal> WightEmpty { get; set; }
        public virtual Item Item { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
