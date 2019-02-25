using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.Models.ViewModels
{
    public class CardRegistration
    {

        [Display(Name = "Long card number")]
        public string CardNumber { get; set; }

        //[StringLength(3, ErrorMessage = "The {0} must be exactly {1} characters long.")]
        [Display(Name = "CVC")]
        public string CVC { get; set; }

        public string Id { get; set; }

        public string Email { get; set; }

        [Display(Name = "ExpiryDate")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

    }
}
