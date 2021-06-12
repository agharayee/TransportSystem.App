using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportSystem.Data.DbModels
{
    public class Seat
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public bool IsSeatAvailable { get; set; }
        public Bus Bus { get; set; }
        public int BusId { get; set; }


    }
}
