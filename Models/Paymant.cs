using System;
using System.Collections.Generic;

namespace RabApiWithMvc.Models
{
    public  class Paymant
    {
        public int PayId { get; set; }
        public Nullable<decimal> PayAmount { get; set; }
        public Nullable<System.DateTime> PayDate { get; set; }
        public Nullable<int> ClntId { get; set; }
        public Nullable<int> VauId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Vaucher Vaucher { get; set; }
    }
}
