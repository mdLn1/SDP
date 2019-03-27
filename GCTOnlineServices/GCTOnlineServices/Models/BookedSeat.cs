using System;
using System.Collections.Generic;

namespace GCTOnlineServices.Models
{
    public partial class BookedSeat
    {
        public BookedSeat()
        {
            BasketTickets = new HashSet<BasketTicket>();
        }

        public int Id { get; set; }
        public int PerformanceId { get; set; }
        public int SeatId { get; set; }
        public byte Booked { get; set; }
        public DateTime? ExpiryTime { get; set; }

        public virtual Performance Performance { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ICollection<BasketTicket> BasketTickets { get; set; }
    }
}
