using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public partial class Vaucher
    {
        public Vaucher()
        {
            this.VaucherDetiles = new List<VaucherDetile>();
        }

        public int VauId { get; set; }
        public Nullable<System.DateTime> VauDate { get; set; }
        public Nullable<int> ClntId { get; set; }
        public Nullable<int> SlOrdId { get; set; }
        public Nullable<decimal> VauAmount { get; set; }
        public Nullable<decimal> PayAmount { get; set; }
         

  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public System.DateTime DateCreated { get; set; }
        public string VauAmoTxt { get; set; }
        public Nullable<decimal> VauOldAmunt { get; set; }
        public Nullable<bool> VauStatus { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<VaucherDetile> VaucherDetiles { get; set; }
        public virtual ICollection<Paymant> Paymants { get; set; }
    }
}
