using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.Dbcontexts;
using TransportSystem.Data.DbModels;
using TransportSystem.ViewModels;

namespace TransportSystem.Service.TerminalServices
{
    public class TerminalService : ITerminalService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TerminalService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateTerminal(TerminalViewModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                var busTerminal = _mapper.Map<Terminal>(model);
                _context.Terminals.AddAsync(busTerminal);
                 _context.SaveChanges();
            }
        }

        public void DeleteTerminal(int Id)
        {
            var terminal = _context.Terminals.FirstOrDefault(t => t.Id == Id);
            _context.Terminals.Remove(terminal);
        }

        public bool TerminalExists(int terminalId)
        {
            return _context.Terminals.Any(a => a.Id == terminalId);
        }

        public IEnumerable<Terminal> GetAllTerminal()
        {
            //Get all Terminal
            return _context.Terminals.ToList();
        }



        public Terminal GetTerminalById(int? Id)
        {
            var terminal = _context.Terminals.FirstOrDefault(t => t.Id == Id);
            return terminal;
        }

        public void UpdateTerminal(int Id)
        {
            throw new NotImplementedException();
        }
        
        public void EditTerminal(int terminalId, TerminalViewModel model)
        {
            if (terminalId != model.Id)
            {
                    _context.Update(model);
                    _context.SaveChanges();  
            }
        }
    }
}
