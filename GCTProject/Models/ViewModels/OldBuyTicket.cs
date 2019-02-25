using GCTProject.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.Models.ViewModels
{
    public class OldBuyTicket
    {
        public int PerformanceDateId { get; set; }
        public string DiscountedPrices { get; set; }
        public string PriceBand { get; set; }
        public bool DiscountApplied { get; set; }
        public List<string> RowNames { get; set; }
        public List<decimal> Costs { get; set; }
        public DateTime SelectedDate { get; set; }
        public string PerformanceName { get; set; }
        public string SavedSeats { get; set; }
        public List<BookedSeats> BookedSeats { get; set; }
        public int Total { get; set; }
        public string Message { get; set; }
        public string UserEmail { get; set; }
        public bool RememberMe { get; set; }
    }
}
