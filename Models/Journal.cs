using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class Journal
    {
        public int id { get; set; }
        public Nullable<int> jornalType { get; set; }
        public string jorText { get; set; }
        public Nullable<decimal> jorAmount { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> jorDate { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> creadit { get; set; }
        public int debType { get; set; }
        public int debId { get; set; }
        public int creadType { get; set; }
        public int creadId { get; set; }
    }
}
