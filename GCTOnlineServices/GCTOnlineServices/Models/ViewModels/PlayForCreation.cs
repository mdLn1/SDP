using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.ViewModels
{

    public class PlayForCreation
    {

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(4, 200.00)]
        [Display(Name = "Starting Price")]
        public decimal PriceStart { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(6,200.00)]
        [Display(Name = "Last Price")]
        public decimal PriceEnd { get; set; }

        [Display(Name = "Performance Date and time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public List<DateTime> LiveDates { get; set; }

        [Required]
        [StringLength(100, MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }
        
        [Display(Name= "Age Restriction")]
        public string AgeRestriction { get; set; }

        public IFormFile Picture { get; set; }

    }

   
}
