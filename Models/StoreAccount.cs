using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class StoreAccount
    {
        public int Id { get; set; }
        public Nullable<int> RefId { get; set; }
        public string RefType { get; set; }
        public Nullable<decimal> StoreCreditor { get; set; }
        public Nullable<decimal> StoreDebit { get; set; }
        public Nullable<int> AccType { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
       
    }
}
