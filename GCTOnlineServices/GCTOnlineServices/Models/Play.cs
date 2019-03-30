using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Starting Price")]
        public decimal PriceStart { get; set; }
        [Display(Name = "Last Price")]
        public decimal PriceEnd { get; set; }
        [Display(Name = "Play Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Age Restriction")]
        public string AgeRestriction { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Performance> Performances { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
