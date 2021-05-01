using addon365.FindMatch360.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }


        public IActionResult quicksearch()
        {
            return View();
        }


        public IActionResult keywordsearch()
        {
            return View();
        }



        public IActionResult idsearch()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }



        public IActionResult Upgrade()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult SuccessStory()
        {
            return View();
        }


        public IActionResult Events()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }


        public IActionResult profile()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
       

    }
}
