using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.Dbcontexts;
using TransportSystem.Data.DbModels;
using TransportSystem.ViewModels;

namespace TransportSystem.Service.BusesServices
{
    public class BusService : IBusService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public BusService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<Terminal> AddNewBus()
        {
            var terminals = _context.Terminals.ToList();
            return terminals;
        }

        public void FindBusById(int Id)
        {
            throw new NotImplementedException();
        }

        public void GetAllBuses()
        {
            throw new NotImplementedException();
        }
    }
}
