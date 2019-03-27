using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.ViewModels
{
    public class ViewBasket
    {
        public List<TicketsInBasket> tickets { get; set; }
        public List<string> DeliveryMethod { get; set; }
        public decimal Total { get; set; }
        public bool RememberMe { get; set; }
        public string CustomerName { get; set; }
    }
}
