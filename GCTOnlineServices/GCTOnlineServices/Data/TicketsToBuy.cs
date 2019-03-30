using GCTOnlineServices.Models;
using GCTOnlineServices.Models.OOPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GCTOnlineServices.Data
{
    // singleton implementation
    public class TicketsToBuy : ITicketsToBuy
    {

        private static TicketsToBuy instance = null;

        private List<TheatreSeat> selectedSeats;

        private TicketsToBuy()
        {
            selectedSeats = new List<TheatreSeat>();
        }

        // get the instance if already created
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static TicketsToBuy GetInstance()
        {
            if (instance == null)
            {
                instance = new TicketsToBuy();
            }
            return instance;
        }

        // add a seat
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddSeat(TheatreSeat seat)
        {
            selectedSeats.Add(seat);
        }

        //remove a seat
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteSeat(int id)
        {
            foreach (TheatreSeat seat in selectedSeats)
            {
                if (seat.Id == id)
                {
                    selectedSeats.Remove(seat);
                    return;
                }
            }
        }

        // selected seats to be returned
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<TheatreSeat> GetSelectedSeats()
        {   
            return selectedSeats;
        }

        //clear the list and reinstanciate it
        public void RemoveAllSelectedSeats()
        {
            if (selectedSeats.Any())
                selectedSeats.Clear();

            selectedSeats = new List<TheatreSeat>();
        }
        

    }
}
