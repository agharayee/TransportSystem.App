using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.DbModels;
using TransportSystem.ViewModels;

namespace TransportSystem.Service.TerminalServices
{
    public interface ITerminalService
    {
        void CreateTerminal(TerminalViewModel model);
        void UpdateTerminal(int Id);
        void DeleteTerminal(int Id);
        IEnumerable<Terminal> GetAllTerminal();
        Terminal GetTerminalById(int? Id);
        bool TerminalExists(int terminalId);
        void EditTerminal(int terminalId, TerminalViewModel model);
    }
}
