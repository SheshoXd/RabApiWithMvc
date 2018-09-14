using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public  class Area
    {
        public Area()
        {
            this.Clients = new List<Client>();
            this.Suppliers = new List<Supplier>();
        }

        public int AreaId { get; set; }
        public string Area1 { get; set; }
        public string City { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> dateCreated { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
