using System;
using System.Collections.Generic;

namespace GCTOnlineServices.Models
{
    public partial class BasketTicket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PerformanceId { get; set; }
        public int BookedSeatId { get; set; }
        public decimal Price { get; set; }

        public virtual BookedSeat BookedSeat { get; set; }
        public virtual Performance Performance { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
