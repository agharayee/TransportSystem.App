using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Service.TerminalServices;
using TransportSystem.ViewModels;

namespace TransportSystem.Controllers
{
    public class TerminalController : Controller
    {
        private readonly ITerminalService _service;
        private readonly IMapper _mapper;
        public TerminalController(ITerminalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public ActionResult<IEnumerable<TerminalViewModel>> Index()
        {
            var Terminals = _service.GetAllTerminal();
            return View(_mapper.Map<IEnumerable<TerminalViewModel>>(Terminals));
        }

        [HttpGet]
        public IActionResult CreateTerminal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTerminal(TerminalViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _service.CreateTerminal(model);
            return View();
        }

        public IActionResult UpdateTerminal(TerminalViewModel model)
        {
            return View();
        }

    }
}
