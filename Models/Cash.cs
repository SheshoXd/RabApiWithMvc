using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public  class Cash
    {
        public int CashId { get; set; }
        public string PayType { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> Creditor { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DataCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
