using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class SaleOrder
    {
        public SaleOrder()
        {
            this.SaleOrdersDetails = new List<SaleOrdersDetail>();
        }

        public int SlOrdId { get; set; }
        public Nullable<int> EmpId { get; set; }
        public int ClntId { get; set; }
        public Nullable<System.DateTime> SlOrdDate { get; set; }
        public Nullable<int> PaymantType { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> Creditor { get; set; }
        public Nullable<int> PostingStats { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
           [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<SaleOrdersDetail> SaleOrdersDetails { get; set; }
         ///public  ICollection<SaleOrdersDetail> SaleOrdersDetails { get; set; }
    }
}
