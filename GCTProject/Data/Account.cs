using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class Account
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public int? Cvc { get; set; }
        public string ExpiryDate { get; set; }
        public string Last4 { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
