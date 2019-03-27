using GCTOnlineServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class ClientBasket
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<TicketForBasket> Tickets { get; set; }
        public string ShippingMethod { get; set; }

    }
}
