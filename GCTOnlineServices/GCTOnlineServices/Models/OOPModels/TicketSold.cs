using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class TicketSold : TicketForBasket
    {
        public string CustomerName { get; set; }
        public decimal PaidPrice { get; set; }
    }
}
