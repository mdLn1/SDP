using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class BasketTickets
    {
        public string UserId { get; set; }
        public int BookedSeatId { get; set; }

        public virtual BookedSeats BookedSeat { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
