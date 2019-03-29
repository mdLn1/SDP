using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.ViewModels
{
    public class EditUserDetails
    {

        public string Id { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Name")]
        public string AgencyOrClubName { get; set; }
        
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Postal Code")]
        public string PostCode { get; set; }
        
        [Display(Name = "First Line of Address")]
        public string FLAddress { get; set; }

        [Display(Name = "Second Line of Address (optional)")]
        public string SLAddress { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Remove saved card")]
        public bool? RemoveSavedCard { get; set; }
    }
}
