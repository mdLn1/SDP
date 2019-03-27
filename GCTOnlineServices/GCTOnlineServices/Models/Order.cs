using System;
using System.Collections.Generic;

namespace GCTOnlineServices.Models
{
    public partial class Order
    {
        public Order()
        {
            SoldTickets = new HashSet<SoldTicket>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClientName { get; set; }
        public string PlayName { get; set; }
        public DateTime OrderTime { get; set; }
        public string DeliveryMethod { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<SoldTicket> SoldTickets { get; set; }
    }
}
