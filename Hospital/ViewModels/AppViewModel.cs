using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string LoginUserID { get; set; }
    }

    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }

    public class ResponseViewModel
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public dynamic Data { get; set; }
        public dynamic Chat { get; set; }
        public string loginId { get; set; }
    }
}
