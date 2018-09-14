using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class GLAccount
    {
        public int GLAccId { get; set; }
        public string AccType { get; set; }
        public Nullable<int> AccId { get; set; }
        public Nullable<decimal> GlCreditor { get; set; }
        public Nullable<decimal> GLDebit { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<decimal> GLBalance { get; set; }
        
    }
}
