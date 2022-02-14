using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string OTP { get; set; }
        
    }

    public class changePassViewModel
    {
        [DisplayName("Email")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Old password is required")]
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }
        [MinLength(6)]
        [DisplayName("New Password")]
        [Required(ErrorMessage = "Password length must be '6' digit")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DisplayName("Confirm new password")]
        public string ConfirmPassword { get; set; }
    }
}
