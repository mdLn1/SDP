using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class Performance
    {
        public Performance()
        {
            PerformanceDate = new HashSet<PerformanceDate>();
            Review = new HashSet<Review>();
        }

        public string Id { get; set; }
        public string PriceBand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AgeRestriction { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<PerformanceDate> PerformanceDate { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
