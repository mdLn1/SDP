using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class Seats
    {
        public Seats()
        {
            BookedSeats = new HashSet<BookedSeats>();
        }

        public int Id { get; set; }
        public string RowName { get; set; }
        public string ColumnNumber { get; set; }

        public virtual ICollection<BookedSeats> BookedSeats { get; set; }
    }
}
