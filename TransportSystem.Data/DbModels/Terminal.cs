using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportSystem.Data.Dbcontexts;

namespace TransportSystem.Data.DbModels
{
    public class Terminal
    {
        public int Id { get; set; }
        [Display(Name = "Departing Terminal")]
        public string TerminalName { get; set; }
        public List<Bus> Bus { get; set; } 
        public List<DepartingTerminal> DepartingTerminals { get; set; } = new List<DepartingTerminal>();
    }
}
