using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.Models.ViewModels
{
    public class Register
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Agency or Social Club? Please tick the box below.")]
        public bool CustomerRegistration { get; set; } = false;

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "First Line of Address")]
        public string FLAddress { get; set; }
        
        [Display(Name = "Second Line of Address (optional)")]
        public string SLAddress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


    }
}
