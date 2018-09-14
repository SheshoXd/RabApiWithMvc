using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class Employee
    {
        public Employee()
        {
            this.PurchaseOrders = new List<PurchaseOrder>();
            this.SaleOrders = new List<SaleOrder>();
        }

        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
    }
}
