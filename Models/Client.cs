using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class Client
    {
        public Client()
        {
            this.ClientAccounts = new List<ClientAccount>();
            this.Creadits = new List<Creadit>();
            this.Paymants = new List<Paymant>();
            this.SaleOrders = new List<SaleOrder>();
            this.Vauchers = new List<Vaucher>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClntId { get; set; }
        public string ClntName { get; set; }
        public string Type { get; set; }
        public string fullAddress { get; set; }
        public string OwnerName { get; set; }
        public Nullable<int> PhoneNo { get; set; }
        public Nullable<int> AreaId { get; set; }


        public Nullable<decimal> ClntDebit { get; set; }
        public Nullable<decimal> ClntCreditor { get; set; }
         [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<decimal> ClntBalance { get; set; }
        public Nullable<decimal> ClntMaxBalance { get; set; }
        public Nullable<decimal> ClntPaymants { get; set; }
          [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<ClientAccount> ClientAccounts { get; set; }
        public virtual ICollection<Creadit> Creadits { get; set; }
        public virtual ICollection<Paymant> Paymants { get; set; }
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
        public virtual ICollection<Vaucher> Vauchers { get; set; }
    }
}
