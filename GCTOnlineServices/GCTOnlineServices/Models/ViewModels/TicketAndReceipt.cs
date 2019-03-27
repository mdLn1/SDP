using GCTOnlineServices.Models.OOPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.ViewModels
{
    public class TicketAndReceipt
    {
        public List<TicketsInBasket> Tickets { get; set; }
        public DateTime Date { get; set; }
        public string PlayName { get; set; }
        public string PersonName { get; set; }
        public decimal TotalCost { get; set; }
        public bool DiscountApplied { get; set; }
        public decimal Saved { get; set; }
    }
}
