using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class TicketOrder
    {
        private decimal totalPaid = 0;
        public int Id { get; set; }
        public string PlayName { get; set; }
        public int NumberOfTickets { get => TicketsOrdered.Count; }
        public DateTime OrderTime { get; set; }
        public string DeliveryMethod { get; set; }
        public List<TicketSold> TicketsOrdered { get; set; }
        public string ClientName { get; set; }
        public decimal TotalPaid { get => totalPaid; set { foreach (TicketSold ticket in TicketsOrdered) totalPaid += ticket.Price; } }


    }
}
