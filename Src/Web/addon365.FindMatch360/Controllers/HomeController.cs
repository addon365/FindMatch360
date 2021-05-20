using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ilamaiMatrimonyContext _context;
        private PreRegisterViewModel _preRegisterViewModel;
        private ProfileViewModel _profileViewModel;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, ilamaiMatrimonyContext context, UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var ProfileForList = _context.ProfileForMasters.ToList();
            PreRegisterViewModel preRegisterViewModel = new PreRegisterViewModel();
            preRegisterViewModel.ProfileForList = ProfileForList;
            return View(preRegisterViewModel);
        }
        [HttpPost]
        public IActionResult Index(PreRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _preRegisterViewModel = model;
                return RedirectToAction("CampaignRegistrationTrack", model);
            }
            return View(model);
        }
        public IActionResult CampaignRegistrationTrack(PreRegisterViewModel model)
        {
            RegisterViewModel registerModel = new RegisterViewModel();

            registerModel.FullName = model.FullName;
            registerModel.ProfileFor = model.ProfileFor;
            registerModel.MobileNo = model.MobileNo;
            registerModel.Gender = model.Gender;
            ViewData["Religions"] = new SelectList(_context.ReligionMasters, "ReligionMasterId", "ReligionName");
            ViewData["MotherTongues"] = new SelectList(_context.MotherTongueMasters, "MotherTongueMasterId", "MotherTongueName");
            return View(registerModel);
        }
        [HttpPost]
        public async Task<IActionResult> CampaignRegistrationTrack(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                    return RedirectToAction("campaignregistration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewData["Religions"] = new SelectList(_context.ReligionMasters, "ReligionMasterId", "ReligionName");
            ViewData["MotherTongues"] = new SelectList(_context.MotherTongueMasters, "MotherTongueMasterId", "MotherTongueName");
            return View(model);
        }

        public IActionResult CampaignRegistration()
        {
            CampaignRegistrationViewModel viewModel = new CampaignRegistrationViewModel();
            viewModel.Castes = _context.CasteMasters.ToList();
            viewModel.SubCastes = _context.SubCasteMasters.ToList();
            viewModel.Gothrams = _context.GothramMasters.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CampaignRegistration(CampaignRegistrationViewModel model)
        {
            return View();
        }

        public IActionResult CampaignRegistrationCaste()
        {
            return View();
        }


        public IActionResult CampaignRegistrationProfessionalDetails()
        {
            return View();
        }


        public IActionResult campaignregistrationpersonaldetails()
        {
            return View();
        }


        public IActionResult campaignregistrationabout()
        {
            return View();
        }



        public IActionResult campaignregistrationphoto()
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
