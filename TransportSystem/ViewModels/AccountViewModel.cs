using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage ="First Name is required")]
        [Display(Name ="First Name")]
        [MaxLength(30)]
        public string FirstName { get; set; }
       
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [MaxLength(30)]
        public string LastName { get; set; }
      
        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage ="Not a valid email please try again")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Next of kin Name is required")]
        [Display(Name = "Next of kin Full Name")]
        [MaxLength(30)]
        public string NextOfKinName { get; set; }
       
        [Required(ErrorMessage = "Next of kin phone number is required")]
        [Display(Name = "Next of Kin Phone Number")]
        [MaxLength(15)]
        public string NextOfKinPhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get;  set; }
       
        [Required(ErrorMessage = "Confirm Password is required")]
        [Display(Name = "Confirm Password")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and Confirm password Mismatch")]
        public string ComfirmPassword { get; set; }
        public string Username { get; set; }
    }
}
