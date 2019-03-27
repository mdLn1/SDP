using GCTOnlineServices.Models.OOPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Data
{
    interface ITicketsToBuy
    {
        void AddSeat(TheatreSeat seat);
        void DeleteSeat(int id);
        List<TheatreSeat> GetSelectedSeats();
        void RemoveAllSelectedSeats();
    }
}
