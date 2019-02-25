using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class AgencyOrClub
    {
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
