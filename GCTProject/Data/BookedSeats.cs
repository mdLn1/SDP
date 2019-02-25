using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class BookedSeats
    {
        public BookedSeats()
        {
            BasketTickets = new HashSet<BasketTickets>();
        }
        public int Id { get; set; }
        public int PerformanceDateId { get; set; }
        public int Seatid { get; set; }
        public byte Booked { get; set; }
        public DateTime? ExpiryTime { get; set; }

        public virtual PerformanceDate PerformanceDate { get; set; }
        public virtual Seats Seat { get; set; }
        public virtual ICollection<BasketTickets> BasketTickets { get; set; }
    }
}
