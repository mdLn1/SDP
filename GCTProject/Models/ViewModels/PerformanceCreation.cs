using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GCTProject.Models.ViewModels
{
    public enum AgeGroup
    {
        [Display(Name = "U")]
        U,
        [Display(Name = "PG")]
        PG,
        [Display(Name = "12")]
        Twelve,
        [Display(Name = "15")]
        Fifteen,
        [Display(Name = "18")]
        Eighteen

    }

    public class PerformanceCreation
    {

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(4, 200.00)]
        [Display(Name = "Starting Price")]
        public decimal PriceStart { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(4,200.00)]
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

        [EnumDataType(typeof(AgeGroup))]
        [Display(Name= "Age Restriction")]
        [DefaultValue(AgeGroup.U)]
        public AgeGroup AgeRestriction { get; set; }

        public IFormFile Picture { get; set; }

    }

   
}
