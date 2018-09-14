using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.ModelViews
{
    public class ClientAccountVM
    {
        public int ClntAccId { get; set; }
        public Nullable<int> ClntId { get; set; }
        public string ClntName { get; set; }
        public Nullable<decimal> ClntDebit { get; set; }
        public Nullable<decimal> ClntCreditor { get; set; }

        public Nullable<decimal> ClntBalance { get; set; }
           

        public Nullable<System.DateTime> DateCreated { get; set; }
        public string MoveType { get; set; }
       
  
    }
}
