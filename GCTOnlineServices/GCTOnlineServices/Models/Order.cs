using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCTOnlineServices.Models
{
    public partial class Order
    {
        public Order()
        {
            SoldTickets = new HashSet<SoldTicket>();
        }

        [Display(Name = "Order Number")]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Customer Name")]
        public string ClientName { get; set; }
        [Display(Name = "Date and Time Placed")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "Shipping Chosen")]
        public string DeliveryMethod { get; set; }
        [Display(Name = "Printed")]
        public bool IsPrinted{ get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<SoldTicket> SoldTickets { get; set; }
    }
}
