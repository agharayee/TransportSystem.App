using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportSystem.Data.DbModels;

namespace TransportSystem.Data.DbModels
{
    public class DepartingTerminal
    {
        public int Id { get; set; }
        [Display(Name ="Arrival Terminal")]
        public string DepartingTerminalName { get; set; }
        [Display(Name = "Departing Terminal")]
        public Terminal Terminal { get; set; }
        public int TerminalId { get; set; }
        public List<Bus> Bus { get; set; }
        

    }
}
