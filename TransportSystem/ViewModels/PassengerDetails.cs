using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.ViewModels
{
    public class PassengerDetails
    {
        [Required(ErrorMessage ="First Name is required")]
        [MaxLength(30)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string TravellerEmail { get; set; }
        [Required(ErrorMessage ="Phone Number is required")]
        [Display(Name ="Phone Number")]
        public string TravellerPhoneNumber { get; set; }
        [Required(ErrorMessage ="Next of Kin Name is required")]
        [Display(Name = "Next of Kin Name")]
        public string NextOfKinName { get; set; }
        [Required(ErrorMessage = "Next of kin is required")]
        [MaxLength(30)]
        [Display(Name = "Next of kin Phone number")]
        public string NextOfKinPhoneNumber { get; set; }
    }
}
