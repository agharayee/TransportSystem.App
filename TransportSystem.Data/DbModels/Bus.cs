using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportSystem.Data.DbModels
{
    public class Bus
    {
        public int Id { get; set; }
        public string  BusName { get; set; }
        public Terminal Terminal { get; set; }
        public int TerminalID { get; set; }
        public DepartingTerminal DepartingTerminal { get; set; }
        public int DepartingTerminalId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        public int TotalSeats{ get; set; }
        public bool IsAcAvailable { get; set; }
        public bool IsPickUpAvailable { get; set; }
        public List<Seat> Seat { get; set; } = new List<Seat>();
       
    }
}
