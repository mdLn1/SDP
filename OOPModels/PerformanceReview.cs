using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string PerformanceName { get; set; }
    }
}
