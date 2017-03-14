using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using taghelpers.Models;

namespace taghelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = new User()
            {
                Id = 1,
                Name = "luru",
                Email = "lruiz@plainconcepts.com"
            };

            return View(user);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
