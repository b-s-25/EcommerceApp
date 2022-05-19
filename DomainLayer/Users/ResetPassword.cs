using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainLayer.Users
{
   public class ResetPassword
    {
        /*public int resetId { get; set; }
        public Registration user { get; set; }
        [Required(ErrorMessage = "*Password is required")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [RegularExpression("[^ ]{8,16}", ErrorMessage = "Password should contain a minimum of 8 characters and a capital letter")]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "*Password is required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("newPassword")]
        public string confirmPassword { get; set; }*/
        [Required]
        public string userId { get; set; }

        [Required]
        public string token { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string newPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("newPassword")]
        [Display(Name = "Confirm New Password")]
        public string confirmNewPassword { get; set; }

        public bool isSuccess { get; set; }
    }
}
