using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace McMovies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Personal Movie Organizer";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact McMovies.net";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}