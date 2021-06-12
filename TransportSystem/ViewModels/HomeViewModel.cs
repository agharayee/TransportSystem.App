using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.ViewModels
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Departure Terminal")]
        [Required(ErrorMessage ="Departure Terminal is required")]
        public string TerminalName { get; set; }
        public int DepartingTerminalNameId { get; set; }
        [Display(Name = "Arrival Terminal")]
        [Required(ErrorMessage = "Arrival Terminal is required")]
        public string DepartingTerminalName { get; set; }
        [Display(Name = "Departure Date")]
        [Required(ErrorMessage = "Departure Date is required")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "Number(s) of Adult")]
        [Required(ErrorMessage = "Numbers of adult is required")]
        public int NumberOfAdult { get; set; }

    }
}
