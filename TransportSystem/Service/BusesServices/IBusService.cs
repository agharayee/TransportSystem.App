using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.DbModels;

namespace TransportSystem.Service.BusesServices
{
    public interface IBusService
    {
        public List<Terminal> AddNewBus();
        void FindBusById(int Id);
        
    }
}
