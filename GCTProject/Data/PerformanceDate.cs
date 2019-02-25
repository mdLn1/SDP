using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class PerformanceDate
    {
        public PerformanceDate()
        {
            BookedSeats = new HashSet<BookedSeats>();
        }

        public int Id { get; set; }
        public string PerformanceId { get; set; }
        public DateTime Date { get; set; }

        public virtual Performance Performance { get; set; }
        public virtual ICollection<BookedSeats> BookedSeats { get; set; }
    }
}
