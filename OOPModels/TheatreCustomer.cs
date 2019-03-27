using GCTOnlineServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class TheatreCustomer : GCTUser, IClientProperties
    {
        public ClientBasket clientBasket;
        public string SavedCustomerCard { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ClientBasket ClientBasket { get => clientBasket; set => clientBasket = value; }

        public void AddTicketsToBasket(List<TicketForBasket> ticketsForBasket)
        {
            foreach (TicketForBasket ticket in ticketsForBasket)
                clientBasket.Tickets.Add(ticket);
        }
    }
}
