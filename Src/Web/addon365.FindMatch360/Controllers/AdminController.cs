using addon365.FindMatch360.Data;
using addon365.FindMatch360.ViewModels;
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
        private readonly ilamaiMatrimonyContext _context;
        public AdminController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }
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
            var lst = _context.ReligionMasters.ToList();
            ProfileViewModel viewModel = new ProfileViewModel();
            viewModel.Religions = lst;
            return View(viewModel);
            
        }
    }
}
