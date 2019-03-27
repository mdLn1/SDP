using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCTOnlineServices.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int PlayId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        [StringLength(400, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public virtual Play Play { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
