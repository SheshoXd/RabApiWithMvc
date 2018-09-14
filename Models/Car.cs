using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabApiWithMvc.Models
{
    public partial class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<int> CarId { get; set; }
        public string CarNo { get; set; }
        public string CarDiscripe { get; set; }
        public Nullable<int> EmpId { get; set; }
        public string CarName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }
}
