using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.DbModels;

namespace TransportSystem.ViewModels
{
    public class BusesViewModel
    {
        public int Id { get; set; }
        public string BusName { get; set; }
        [Display(Name ="Departing Terminal")]
        public int TerminalId { get; set; }
        [Display(Name = "Arrival Terminal")]
        public int DepartingTerminalId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        public int TotalSeats { get; set; }
        public bool IsAcAvailable { get; set; }
        public bool IsPickUpAvailable { get; set; }

        public int AvailableSeats { get; set; }


        // public List<Seat> Seat { get; set; } = new List<Seat>();
    }
}
