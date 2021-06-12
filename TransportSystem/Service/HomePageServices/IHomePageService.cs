using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.ViewModels;

namespace TransportSystem.Service.HomePageServices
{
    public interface IHomePageService
    {
        IEnumerable<HomeViewModel> LoadTerminal();
       // IEnumerable<HomeViewModel> LoadDepartingTerminal(int terminalId);

    }
}
