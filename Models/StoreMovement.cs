using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class StoreMovement
    {
        public int StoremoveId { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> OrderDetailsId { get; set; }
        public Nullable<int> MovementType { get; set; }
        public Nullable<decimal> itemQty { get; set; }
        public Nullable<int> type { get; set; }
        public virtual Item Item { get; set; }
    }
}
