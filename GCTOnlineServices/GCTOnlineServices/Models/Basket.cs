using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCTOnlineServices.Models
{
    public partial class Basket
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string ShippingMethod { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
