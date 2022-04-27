using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainLayer.DTO
{
    public class RegistrationView
    {
        [Key]
        public int registrationId { get; set; }
        [Required(ErrorMessage = "*First Name is required")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "*Last Name is required")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "*Email Address is required")]
        [EmailAddress(ErrorMessage = "*Email address should be in the format adc@domain.com")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "*Password is required")]
        [RegularExpression("[^ ]{8,16}", ErrorMessage = "Password should contain a minimum of 8 characters and a capital letter")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "*Confirm Password is required")]
        [Compare(nameof(password), ErrorMessage = "*Password should match with Confirm Password")]    
        [Display(Name = "Confirm Password")]
        public string confirmPassword { get; set; }
    }
}
