using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TransportSystem.Data.Dbcontexts;
using TransportSystem.Data.Entities;
using TransportSystem.Models;
using TransportSystem.Service.HomePageServices;
using TransportSystem.ViewModels;

namespace TransportSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageService _service;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, IHomePageService service, ApplicationDbContext context, 
                              IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _service = service;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Terminal = _service.LoadTerminal();
            return View();
        }


        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            HttpContext.Session.SetString("DepartingTerminal", model.TerminalName.ToString());
            HttpContext.Session.SetString("ArrivalTerminal", model.DepartingTerminalName.ToString());
            HttpContext.Session.SetInt32("NumberOfAdult", model.NumberOfAdult);
            HttpContext.Session.SetString("DepartureDate", model.DepartureDate.ToString());

            return RedirectToAction("BusSelection");
        }
        [HttpGet]
        public IActionResult LocalDepartingTerminal(int terminalId)
        {
            var departingTerminal = _context.DepartingTerminal.Where(s => s.TerminalId == terminalId).Select(l => new
            {
                id = l.Id,
                Name = l.DepartingTerminalName,
            }).ToList();
            return Json(departingTerminal);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult BusSelection()
        {
            string terminal =  ViewBag.DepartingTerminal = HttpContext.Session.GetString("DepartingTerminal");
            int tid = int.Parse(terminal);
            var foundTerminal = _context.Terminals.FirstOrDefault(t => t.Id == tid);
            ViewBag.Terminal = foundTerminal.TerminalName;

            string ArrivalTerminal = ViewBag.ArrivalTerminal = HttpContext.Session.GetString("ArrivalTerminal");
            int aid = int.Parse(ArrivalTerminal);
            var foundArrivalTerminal = _context.DepartingTerminal.FirstOrDefault(t => t.Id == aid);
           
            ViewBag.ArrivalTerminal = foundArrivalTerminal.DepartingTerminalName;
            ViewBag.NumberOfAdult = HttpContext.Session.GetInt32("NumberOfAdult");
            ViewBag.DepartureDate = HttpContext.Session.GetString("DepartureDate");

            
            var busToLocation = _context.Buses.Include(b => b.Terminal).Include(b => b.DepartingTerminal).Include(b=> b.Seat).Where
                                                          (b => (b.TerminalID == tid) && (b.DepartingTerminalId == aid));

            var mapped = _mapper.Map<IEnumerable<BusSelectionViewModel>>(busToLocation);
            //foreach (var item in busToLocation)
            //{
            //    var count = item.Seat.Where(s => s.IsSeatAvailable == true).Count();
            //    var availableSeat = item.TotalSeats - count;
            //    BusSelectionViewModel bv = new BusSelectionViewModel
            //    {
            //        Terminal = item.Terminal.TerminalName,
            //        DepartingTerminal = item.DepartingTerminal.DepartingTerminalName,
            //        DepartureTime = item.DepartureTime,
            //        BusName = item.BusName,
            //        IsAcAvailable =item.IsAcAvailable,
            //        IsPickUpAvailable = item.IsPickUpAvailable,
            //        TotalSeats = item.TotalSeats,
            //        Amount = item.Amount,
            //        AvailableSeats = availableSeat,
            //    };
            //    return View(bv);
            //}
            return View(mapped);
           
        }

        [HttpPost]
        public IActionResult GetSeatNumber(BusSelectionViewModel model)
        {
            if(ModelState.IsValid)
            {
                return Redirect("PassengerDetails");
            }
            return View();
        }
        public IActionResult GetAvaibaleSeat(int BusId)
        {

            var availableSeat = _context.Seats.Where(s => s.BusId == BusId).Where(s => s.IsSeatAvailable == true).Select(l => new
            {
                id = l.SeatNumber,
                name = l.SeatNumber
            }).ToList();
            return Json(availableSeat);
        }

        public async Task<IActionResult> PassengerDetails()
        {
            string terminal = ViewBag.DepartingTerminal = HttpContext.Session.GetString("DepartingTerminal");
            int tid = int.Parse(terminal);
            var foundTerminal = _context.Terminals.FirstOrDefault(t => t.Id == tid);
            ViewBag.Terminal = foundTerminal.TerminalName;

            string ArrivalTerminal = ViewBag.ArrivalTerminal = HttpContext.Session.GetString("ArrivalTerminal");
            int aid = int.Parse(ArrivalTerminal);
            var foundArrivalTerminal = _context.DepartingTerminal.FirstOrDefault(t => t.Id == aid);

            ViewBag.ArrivalTerminal = foundArrivalTerminal.DepartingTerminalName;

            if (_signInManager.IsSignedIn(User))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                PassengerDetails details = new PassengerDetails
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    TravellerEmail = user.Email,
                    TravellerPhoneNumber = user.PhoneNumber,
                    NextOfKinName = user.NextOfKinName,
                    NextOfKinPhoneNumber = user.NextOfKinPhoneNumber,
                };
                return View(details);
            }
            else
                return View();
            

        }
        [HttpPost]
        public IActionResult PassengerDetails(PassengerDetails model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Payment");
            }
            else return View(model);
        }

        public IActionResult Payment()
        {
            return View();
        }
    }
}
