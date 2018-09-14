using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class Item
    {
        public Item()
        {
            this.PurchaseOrdersDetails = new List<PurchaseOrdersDetail>();
            this.SaleOrdersDetails = new List<SaleOrdersDetail>();
            this.StoreItems = new List<StoreItem>();
            this.StoreMovements = new List<StoreMovement>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal AverageCost { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal itemQyt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal availableQty { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal OpenBlance { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<decimal> UnPostedQty { get; set; }
        public int UintId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public System.DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<decimal> itemDepr { get; set; }
        public virtual Uint Uint { get; set; }
        public virtual ICollection<PurchaseOrdersDetail> PurchaseOrdersDetails { get; set; }
        public virtual ICollection<SaleOrdersDetail> SaleOrdersDetails { get; set; }
        public virtual ICollection<StoreItem> StoreItems { get; set; }
        public virtual ICollection<StoreMovement> StoreMovements { get; set; }

        [NotMapped]
        public string AviQty { get; set; }
    }
}
