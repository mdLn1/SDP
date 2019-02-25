using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class StaffMembers
    {
        public string UserId { get; set; }
        public int Number { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
