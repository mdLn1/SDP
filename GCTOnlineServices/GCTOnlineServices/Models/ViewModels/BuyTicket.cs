 using GCTOnlineServices.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.ViewModels
{
    public class BuyTicket
    {
        public int PerformanceId { get; set; }
        public DateTime SelectedDate { get; set; }
        public SelectList LiveDates { get; set; }
        public string PerformanceName { get; set; }
        public string PriceBand { get; set; }
        public string Description { get; set; }
        public string AgeRestriction { get; set; }
        public byte[] Picture { get; set; }
        

    }
}
