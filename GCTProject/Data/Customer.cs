using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class Customer
    {
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
