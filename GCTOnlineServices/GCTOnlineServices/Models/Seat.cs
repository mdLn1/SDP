using System;
using System.Collections.Generic;

namespace GCTOnlineServices.Models
{
    public partial class Seat
    {
        public Seat()
        {
            BookedSeats = new HashSet<BookedSeat>();
        }

        public int Id { get; set; }
        public string Band { get; set; }
        public string ColumnLetter { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

        public virtual ICollection<BookedSeat> BookedSeats { get; set; }
    }
}
