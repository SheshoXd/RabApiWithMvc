using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public class Creadit
    {
        public int id { get; set; }
        public Nullable<int> ClintId { get; set; }
        public Nullable<decimal> CreaditAmount { get; set; }
        public virtual Client Client { get; set; }
    }
}
