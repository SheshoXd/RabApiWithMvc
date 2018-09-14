using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public partial class CasTody
    {
        public int CastodyId { get; set; }
        public string FildType { get; set; }
        public Nullable<int> FildId { get; set; }
        public Nullable<decimal> CasDebet { get; set; }
        public Nullable<decimal> CasCredeit { get; set; }
        public string CasFor { get; set; }
        public Nullable<System.DateTime> CasDate { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }
}
