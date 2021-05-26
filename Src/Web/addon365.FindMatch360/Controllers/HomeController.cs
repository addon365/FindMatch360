using addon365.FindMatch360.Data;
using addon365.FindMatch360.Helpers.Enums;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, ilamaiMatrimonyContext context, UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._httpContextAccessor = httpContextAccessor;
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
        public IActionResult UserRegistrationBasic(PreRegisterViewModel model)
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
        public async Task<IActionResult> UserRegistrationBasic(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var profile = new Profile();
                if (model.ProfileFor != "")
                    profile.ProfileForId = Convert.ToInt32(model.ProfileFor);
                profile.Name = model.FullName;
                profile.MobileNo = model.MobileNo;
                if (model.Gender == Gender.Male.ToString())
                {
                    profile.Gender = (byte)Gender.Male;
                }



                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "MatrimonyUser");
                    profile.UserId = user.Id;
                    _context.Add(profile);
                    _context.SaveChanges();

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

        public IActionResult UserRegistrationReligionDetails()
        {
            CampaignRegistrationViewModel viewModel = new CampaignRegistrationViewModel();
            viewModel.Castes = _context.CasteMasters.ToList();
            viewModel.SubCastes = _context.SubCasteMasters.ToList();
            viewModel.Gothrams = _context.GothramMasters.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistrationReligionDetails(CampaignRegistrationViewModel model)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            currentUser = _httpContextAccessor.HttpContext.User;


            var data = _context.MatrimonyProfiles.Where(a => a.UserId == _userManager.GetUserId(currentUser));
            Profile profile = null;

            if (data.Any())
            {
                if (data.Count() == 1)
                {
                    profile = data.FirstOrDefault();
                    var matrimonyProfile = await _context.MatrimonyProfiles.FindAsync(profile.MatrimonyProfileId);
                    if (model.CasteMasterId != "" && model.CasteMasterId != "0")
                    {
                        matrimonyProfile.CasteMasterId = Convert.ToInt32(model.CasteMasterId);
                    }
                    if (model.SubCasteMasterId != "" && model.SubCasteMasterId != "0")
                    {
                        matrimonyProfile.SubCasteMasterId = Convert.ToInt32(model.SubCasteMasterId);
                    }
                    if (model.GothramMasterId != "" && model.GothramMasterId != "0")
                    {
                        matrimonyProfile.GothramMasterId = Convert.ToInt32(model.GothramMasterId);
                    }

                    _context.Update(matrimonyProfile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("campaignregistrationpersonaldetails");
                }
            }


            return View();
        }

        public IActionResult UserRegistrationPersonalDetails()
        {
            return View();
        }
        public IActionResult UserRegistrationProfessionalDetails()
        {
            return View();
        }
        public IActionResult UserRegistrationPhoto()
        {
            return View();
        }
        public IActionResult CampaignRegistrationCaste()
        {
            return View();
        }


        


        


        public IActionResult campaignregistrationabout()
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
