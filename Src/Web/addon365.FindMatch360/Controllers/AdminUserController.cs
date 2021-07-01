using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    public class AccountAdminController : Controller
    {
        public AccountAdminController()
        {


        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AccountAdminCreateViewModel model)
        {
            if(ModelState.IsValid)
            {


                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

    }
}
