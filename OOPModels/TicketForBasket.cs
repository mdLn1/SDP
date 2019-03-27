using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class TicketForBasket
    {
        public int Id { get; set; }
        public string PerformanceName { get; set; }
        public char Band { get; set; }
        public char ColumnLetter { get; set; }
        public int RowNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PerformanceTimeAndDate { get; set; }

    }
}
