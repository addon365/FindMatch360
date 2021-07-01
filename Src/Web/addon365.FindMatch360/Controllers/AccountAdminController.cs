using addon365.FindMatch360.Helpers;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    public class AccountAdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountAdminController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountAdminCreateViewModel model, [FromServices] IEmailSender emailSender)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.LoginEmailId, Email = model.LoginEmailId,ProfileName=model.Name };
                string password = GeneralHelper.GenerateRandomPassword(); 
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Administrator");

                    await emailSender.SendEmailAsync(model.LoginEmailId, "addon365 password mail", password);
                }


                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Index()
        {

            var users = await _userManager.GetUsersInRoleAsync("Administrator");

            return View(users);
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
