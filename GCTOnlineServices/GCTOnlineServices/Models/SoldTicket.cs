using System;
using System.Collections.Generic;

namespace GCTOnlineServices.Models
{
    public partial class SoldTicket
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string CustomerName { get; set; }
        public decimal PaidPrice { get; set; }
        public string PlayName { get; set; }
        public string Band { get; set; }
        public string ColumnLetter { get; set; }
        public int RowNumber { get; set; }
        public DateTime PerformanceTimeAndDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
