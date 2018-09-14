using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Debits = new List<Debit>();
            this.PurchaseOrders = new List<PurchaseOrder>();
            this.SuppliersAccounts = new List<SuppliersAccount>();
        }

        public int SuppId { get; set; }
        public string SuppName { get; set; }
        public Nullable<int> Type { get; set; }
        public string fullAddress { get; set; }
        public string OwnerName { get; set; }
        public Nullable<int> PhoneNo { get; set; }
        public Nullable<int> AreaId { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public System.DateTime DateCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Debit> Debits { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<SuppliersAccount> SuppliersAccounts { get; set; }
    }
}
