using GCTOnlineServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class TheatreAgencyOrClub : GCTUser
    {
        public ClientBasket clientBasket;
        public string SavedCustomerCard { get; set; }
        public string AgencyOrClubName { get; set; }
        public string Address { get; set; }
        public bool? ApprovedMultipleDiscounts { get; set; }
        public ClientBasket ClientBasket { get => clientBasket; set => clientBasket = value; }

        public void AddTicketsToBasket(List<TicketForBasket> ticketsForBasket)
        {
            foreach(TicketForBasket ticket in ticketsForBasket)
                clientBasket.Tickets.Add(ticket);
        }
    }
}
