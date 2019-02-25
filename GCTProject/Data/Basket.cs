using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class Basket
    {
        public string UserId { get; set; }
        public string ShippingMethod { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
