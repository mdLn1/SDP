using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.Models.ViewModels
{
    public class TicketAndReceipt
    {
        public List<string> Rows { get; set; }
        public List<int> ChairNumber { get; set; }
        public DateTime Date { get; set; }
        public string PerformanceName { get; set; }
        public string PersonName { get; set; }
        public decimal TotalCost { get; set; }
    }
}
