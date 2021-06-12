using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.Dbcontexts;
using TransportSystem.Data.DbModels;
using TransportSystem.Service.BusesServices;
using TransportSystem.ViewModels;

namespace TransportSystem.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _service;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public BusController(IBusService service, ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }
        public IActionResult Index()
        {
            var buses = _context.Buses.Include(d => d.Terminal).Include(d => d.DepartingTerminal);
            return View(buses);
        }

        [HttpGet]
        public IActionResult CreateNewBus()
        {
            var terminal = _context.Terminals.ToList();
            ViewBag.TerminalId = terminal;


            return View();
        }

        [HttpGet]
        public IActionResult LoadArrivalTerminal(int terminalId)
        {
            var departingTerminal = _context.DepartingTerminal.Where(s => s.TerminalId == terminalId).Select(l => new
            {
                id = l.Id,
                Name = l.DepartingTerminalName,
            }).ToList();
            return Json(departingTerminal);
        }

        [HttpPost]
        public IActionResult CreateNewBus(BusesViewModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                if(ModelState.IsValid)
                {
                  
                    var newBus = _mapper.Map<Bus>(model);
                    Seat[] seats = new Seat[model.TotalSeats];
                    var count = seats.Length;
                    Seat seat = new Seat
                    {
                        SeatNumber = 1,
                        IsSeatAvailable = false
                    };
                    seats[0] = seat;
                    for (int i = 1; i < model.TotalSeats; i++)
                    {
                        Seat seat1 = new Seat
                        {
                            SeatNumber = i + 1,
                            IsSeatAvailable = true,
                        };
                        seats[i] = seat1;
                    }

                    //newBus.TotalSeats = model.TotalSeat;
                    newBus.Seat = seats.ToList();
                    _context.Buses.Add(newBus);
                    _context.SaveChanges();
                }

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
