using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class SaleOrdersDetail
    {
        public Nullable<int> ItemId { get; set; }
        public int SlOrdDtId { get; set; }
        public Nullable<int> SlOrdId { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<decimal> SlQty { get; set; }
        public Nullable<int> CaseNumber { get; set; }
        public Nullable<decimal> CaseWight { get; set; }
        public Nullable<int> PostingStatus { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<decimal> WightEmpty { get; set; }
        public virtual Item Item { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
    }
}
