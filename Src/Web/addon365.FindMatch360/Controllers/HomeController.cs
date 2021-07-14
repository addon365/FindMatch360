using addon365.FindMatch360.Data;
using addon365.FindMatch360.Helpers.Enums;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using addon365.FindMatch360.Services;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ilamaiMatrimonyContext _context;
        private UserRegisterIntilizeViewModel _preRegisterViewModel;
        private AdminProfileCreateViewModel _profileViewModel;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ProfileService _profileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, 
            ilamaiMatrimonyContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor,
            ProfileService profileService,IWebHostEnvironment webHostEnvironment
            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._httpContextAccessor = httpContextAccessor;
            this._profileService = profileService;
            this._webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var ProfileForList = _context.ProfileForMasters.ToList();
            UserRegisterIntilizeViewModel preRegisterViewModel = new UserRegisterIntilizeViewModel();
            preRegisterViewModel.ProfileForList = ProfileForList;
            return View(preRegisterViewModel);
        }
        [HttpPost]
        public IActionResult Index(UserRegisterIntilizeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _preRegisterViewModel = model;
                return RedirectToAction("UserRegistrationBasic", model);
            }
            return View(model);
        }
        public IActionResult UserRegistrationBasic(UserRegisterIntilizeViewModel model)
        {
            UserRegistrationBasicViewModel registerModel = new UserRegistrationBasicViewModel();

            registerModel.FullName = model.FullName;
            registerModel.ProfileFor = model.ProfileFor;
            registerModel.MobileNo = model.MobileNo;
            registerModel.Gender = model.Gender;
            ViewData["Religions"] = new SelectList(_context.ReligionMasters, "ReligionMasterId", "ReligionName");
            ViewData["MotherTongues"] = new SelectList(_context.MotherTongueMasters, "MotherTongueMasterId", "MotherTongueName");
            return View(registerModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistrationBasic(UserRegistrationBasicViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var profile = new Profile();
                if (model.ProfileFor != "")
                    profile.ProfileForId = Convert.ToInt32(model.ProfileFor);
                profile.Name = model.FullName;
                profile.MobileNo = model.MobileNo;
                
                if(model.DateOfBirth!="")
                    profile.DateandTimeOfBirth = Convert.ToDateTime(model.DateOfBirth);
               
                if(model.Gender!="0" && model.Gender!="")
                    profile.Gender = (byte)Convert.ToByte(model.Gender);

                profile.ReligionMasterId = ConvertIntandIfvalid(model.ReligionMasterId);
                profile.MotherTongueMasterId = ConvertIntandIfvalid(model.MotherTongueMasterId);
            



                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "MatrimonyUser");
                    profile.UserId = user.Id;
                    if (_context.Profiles.Count() > 0)
                    {
                        profile.RegistrationNo = (_context.Profiles.Max(p => Convert.ToInt64(p.RegistrationNo)) + 1).ToString();
                    }
                    else
                    {
                        profile.RegistrationNo = "1";
                    }
                    _context.Add(profile);
                    _context.SaveChanges();

                    await _signInManager.SignInAsync(user, isPersistent: false);



                    return RedirectToAction("UserRegistrationReligionDetails");
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
            UserRegistrationReligionViewModel viewModel = new UserRegistrationReligionViewModel();
            viewModel.Castes = _context.CasteMasters.ToList();
            viewModel.SubCastes = _context.SubCasteMasters.ToList();
            viewModel.Gothrams = _context.GothramMasters.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistrationReligionDetails(UserRegistrationReligionViewModel model)
        {
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            //currentUser = _httpContextAccessor.HttpContext.User;


            //var data = _context.MatrimonyProfiles.Where(a => a.UserId == _userManager.GetUserId(currentUser));
            //Profile profile = null;

            //if (data.Any())
            //{
            //    if (data.Count() == 1)
            //    {
            //        profile = data.FirstOrDefault();
            //        var matrimonyProfile = await _context.MatrimonyProfiles.FindAsync(profile.MatrimonyProfileId);
            //        if (model.CasteMasterId != "" && model.CasteMasterId != "0")
            //        {
            //            matrimonyProfile.CasteMasterId = Convert.ToInt32(model.CasteMasterId);
            //        }
            //        if (model.SubCasteMasterId != "" && model.SubCasteMasterId != "0")
            //        {
            //            matrimonyProfile.SubCasteMasterId = Convert.ToInt32(model.SubCasteMasterId);
            //        }
            //        if (model.GothramMasterId != "" && model.GothramMasterId != "0")
            //        {
            //            matrimonyProfile.GothramMasterId = Convert.ToInt32(model.GothramMasterId);
            //        }

            //        _context.Update(matrimonyProfile);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction("UserRegistrationPersonalDetails"); 
            //    }
            //}
            Profile profile = _profileService.GetProfile();
            if (profile!=null)
            { 
                var matrimonyProfile = await _context.Profiles.FindAsync(profile.ProfileMasterId);
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
                return RedirectToAction("UserRegistrationPersonalDetails");
            }

            return View();
        }

        public IActionResult UserRegistrationPersonalDetails()
        {
            UserRegistrationPersonalViewModel userRegistrationPersonalViewModel = new UserRegistrationPersonalViewModel();
            userRegistrationPersonalViewModel.MaritalStatusMasters = _context.MaritalStatusMasters;
            userRegistrationPersonalViewModel.FamilyStatuses = _context.FamilyStatusMasters;
            userRegistrationPersonalViewModel.FamilyTypes = _context.FamilyTypeMasters;
            userRegistrationPersonalViewModel.FamilyValues = _context.FamilyValuesMasters;
            return View(userRegistrationPersonalViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistrationPersonalDetails(UserRegistrationPersonalViewModel model)
        {
            Profile profile = _profileService.GetProfile();
            if (profile != null)
            {
                var matrimonyProfile = await _context.Profiles.FindAsync(profile.ProfileMasterId);
                if (model.MaritalStatusMasterId != "" && model.MaritalStatusMasterId != "0")
                {
                    matrimonyProfile.MaritalStatusMasterId = Convert.ToInt32(model.MaritalStatusMasterId);
                }
                if (model.FamilyStatusMasterId != "" && model.FamilyStatusMasterId != "0")
                {
                    matrimonyProfile.FamilyStatusMasterId = Convert.ToInt32(model.FamilyStatusMasterId);
                }
                if (model.FamilyTypeMasterId != "" && model.FamilyTypeMasterId != "0")
                {
                    matrimonyProfile.FamilyTypeMasterId = Convert.ToInt32(model.FamilyTypeMasterId);
                }
                matrimonyProfile.DisabilityDescription = model.Disability;

                _context.Update(matrimonyProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction("UserRegistrationProfessionalDetails");
            }

            return View();
        }

        public IActionResult UserRegistrationProfessionalDetails()
        {
            UserRegistrationProfessionalViewModel model = new UserRegistrationProfessionalViewModel();
            model.Educations = _context.EducationMasters;
            model.EmployeedInLst = _context.EmployeedInMasters;
            model.Occupations = _context.OccupationMasters;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistrationProfessionalDetails(UserRegistrationProfessionalViewModel model)
        {
            Profile profile = _profileService.GetProfile();
            if (profile != null)
            {
                var matrimonyProfile = await _context.Profiles.FindAsync(profile.ProfileMasterId);
                //if (model.EducationMasterId != "" && model.EducationMasterId != "0")
                //{
                //    matrimonyProfile.ProfileEducationMasterId = Convert.ToInt32(model.EducationMasterId);
                    matrimonyProfile.ProfileEducationDetail = model.EducationDetail;
                //}
                if (model.EmployeedInMasterId != "" && model.EmployeedInMasterId != "0")
                {
                    matrimonyProfile.EmployeedInMasterId = Convert.ToInt32(model.EmployeedInMasterId);
                }
                if (model.OccupationMasterId != "" && model.OccupationMasterId != "0")
                {
                    matrimonyProfile.OccupationMasterId = Convert.ToInt32(model.OccupationMasterId);
                }
                if (model.MonthlyRevenue != 0)
                {
                    matrimonyProfile.MonthlyRevenue = model.MonthlyRevenue;
                }

                _context.Update(matrimonyProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction("UserRegistrationPhoto");
            }

            return View();
        }
        public IActionResult UserRegistrationPhoto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistrationPhoto(UserRegistrationPhotoViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    Profile profile = _profileService.GetProfile();
                    if (profile != null)
                    {
                        var matrimonyProfile = await _context.Profiles.FindAsync(profile.ProfileMasterId);

                        string wwwRooPath = _webHostEnvironment.WebRootPath;
                        string fileName = "Pri_";
                        string extension = Path.GetExtension(model.ImageFile.FileName);
                        model.ImageName = fileName = fileName + matrimonyProfile.ProfileMasterId + extension;
                        string path = Path.Combine(wwwRooPath + "/ProfilePhotos/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(fileStream);
                        }
                        matrimonyProfile.PhotoName = model.ImageName;
                        _context.Update(matrimonyProfile);
                        await _context.SaveChangesAsync();
                      
                    }
                }
                return RedirectToAction("index", "MatrimonyProfiles");
            }
            return View();
        }

        public IActionResult CampaignRegistrationCaste()
        {
            return View();
        }

        public IActionResult UserRegistrationAbout()
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


        private int? ConvertIntandIfvalid(string value)
        {
            if (value != "" && value != "0")
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return null;
            }
        }
    }
    
}
