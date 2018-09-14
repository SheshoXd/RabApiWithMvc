using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public class StoreItem
    {
        public int StoreItemId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public decimal itemQyt { get; set; }
        public decimal availableQty { get; set; }
        public decimal OpenBlance { get; set; }
        public  Nullable<decimal> UnPostedQty { get; set; }
        public virtual Item Item { get; set; }
    }
}
