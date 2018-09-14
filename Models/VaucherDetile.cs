using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

namespace RabApiWithMvc.Models
{
    public  class VaucherDetile
    {
        public int VauDtilId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<int> CaseNo { get; set; }
        public Nullable<decimal> CaseWds { get; set; }

       [DatabaseGenerated(DatabaseGeneratedOption.Computed) ]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<int> VauId { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public virtual Vaucher Vaucher { get; set; }
    }
}
