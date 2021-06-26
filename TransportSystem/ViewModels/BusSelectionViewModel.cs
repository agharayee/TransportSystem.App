using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.DbModels;

namespace TransportSystem.ViewModels
{
    public class BusSelectionViewModel
    {
        public int Id { get; set; }
        public string BusName { get; set; }
       
        [Display(Name ="Departing Terminal")]
        public string Terminal { get; set; }
       
        [Display(Name = "Departing Terminal")]
        public string DepartingTerminal { get; set; }
       
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        public int TotalSeats { get; set; }
        public bool IsAcAvailable { get; set; }
        public bool IsPickUpAvailable { get; set; }
        public int SelectedSeat { get; set; }
        public int AvailableSeats { get; set; }
    }
}
