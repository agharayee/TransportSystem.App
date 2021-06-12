using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Views
{
    public class Buses : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
