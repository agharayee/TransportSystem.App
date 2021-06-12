using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.Dbcontexts;
using TransportSystem.Data.DbModels;
using TransportSystem.ViewModels;

namespace TransportSystem.Service.HomePageServices
{
    public class HomePageService : IHomePageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public HomePageService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }
        public IEnumerable<HomeViewModel> LoadTerminal()
        {
            var Terminal = _context.Terminals.ToList();
            var mappedTerminal = _mapper.Map<IEnumerable<HomeViewModel>>(Terminal);
            return mappedTerminal;
        }

    }
}
