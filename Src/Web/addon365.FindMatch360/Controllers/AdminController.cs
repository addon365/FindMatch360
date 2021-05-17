using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PaidList()
        {
            return View();
        }

        public IActionResult paymentoptions()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult CreateProfile()
        {
            return View();
        }
    }
}
