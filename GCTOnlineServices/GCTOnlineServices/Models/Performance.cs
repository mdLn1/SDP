using System;
using System.Collections.Generic;

namespace GCTOnlineServices.Models
{
    public partial class Performance
    {
        public Performance()
        {
            BookedSeats = new HashSet<BookedSeat>();
        }

        public int Id { get; set; }
        public int PlayId { get; set; }
        public DateTime Date { get; set; }

        public virtual Play Play { get; set; }
        public virtual ICollection<BookedSeat> BookedSeats { get; set; }
    }
}
