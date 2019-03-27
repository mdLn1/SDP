using System;
using System.Collections.Generic;

namespace GCTOnlineServices.Models
{
    public partial class Play
    {
        public Play()
        {
            Performances = new HashSet<Performance>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public decimal PriceStart { get; set; }
        public decimal PriceEnd { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AgeRestriction { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Performance> Performances { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
