using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.ViewModels
{
    public class PaymentViewModel
    {
        public string DepartingTerminal { get; set; }
        public string ArriveTerminal { get; set; }
        public decimal Amount { get; set; }
        public decimal Decimal { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}
