using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string IdNumber { get; set; }
        public string AgencyOrClubName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SavedCustomerCard { get; set; }
        public string Address { get; set; }
        public bool? ApprovedMultipleDiscounts { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual BasketTicket BasketTickets { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
