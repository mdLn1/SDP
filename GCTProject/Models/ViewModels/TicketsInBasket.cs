using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.Models.ViewModels
{
    public class TicketsInBasket
    {
        public int Id { get; set; }

        [Display(Name = "Performance")]
        public string PerformanceName { get; set; }

        [Display(Name = "Row")]
        public string RowNumber { get; set; }

        [Display(Name = "Seat")]
        public string SeatNumber { get; set; }

        [Display(Name = "Live Date")]
        public DateTime PerformanceTime { get; set; }

        [Display(Name = "Price")]
        public decimal Cost { get; set; }
       
    }
}
