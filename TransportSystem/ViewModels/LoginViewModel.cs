using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
