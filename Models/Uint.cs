using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public class Uint
    {
        public Uint()
        {
            this.Items = new List<Item>();
        }

        public int UintId { get; set; }
        public string UintName { get; set; }
           [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
