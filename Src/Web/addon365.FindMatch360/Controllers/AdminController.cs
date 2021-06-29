using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    //[Authorize(Roles = "Administrator,User")]
    public class AdminController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;
        private static int _catId;
        private static int _subId;
        public AdminController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var PaidList = await _context.Profiles.Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).ToListAsync();
            AdminDashBoardViewModel viewModel = new AdminDashBoardViewModel();
            viewModel.TotalMembers = 10000;
            viewModel.PaidMembers = 18000;
            viewModel.InactiveMembers = 300;
            viewModel.Visitors = 2000;

            List<RecentMember> recentMembers = new List<RecentMember>();
            recentMembers.Add(new RecentMember { SNo = 1, RegNo = 10048, RegDate = DateTime.Now, Name = "Santhosh", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            recentMembers.Add(new RecentMember { SNo = 2, RegNo = 10049, RegDate = DateTime.Now, Name = "Ramesh", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            recentMembers.Add(new RecentMember { SNo = 3, RegNo = 10050, RegDate = DateTime.Now, Name = "Sarath", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            recentMembers.Add(new RecentMember { SNo = 4, RegNo = 10051, RegDate = DateTime.Now, Name = "Lakshmi", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            recentMembers.Add(new RecentMember { SNo = 5, RegNo = 10052, RegDate = DateTime.Now, Name = "Saravanan", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });

            viewModel.RecentMembers = recentMembers;

            return View(viewModel);
        }


        public async Task <IActionResult> PaidList()
        {
            var PaidList = await _context.Profiles.Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).ToListAsync();
            PaidMembersViewModel viewModel = new PaidMembersViewModel();
            List<PaidMember> paidMembers = new List<PaidMember>();
            paidMembers.Add(new PaidMember { SNo = 1, RegNo = 10048, RegDate = DateTime.Now, Name = "Santhosh", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            paidMembers.Add(new PaidMember { SNo = 2, RegNo = 10049, RegDate = DateTime.Now, Name = "Ramesh", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            paidMembers.Add(new PaidMember { SNo = 3, RegNo = 10050, RegDate = DateTime.Now, Name = "Sarath", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            paidMembers.Add(new PaidMember { SNo = 4, RegNo = 10051, RegDate = DateTime.Now, Name = "Lakshmi", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            paidMembers.Add(new PaidMember { SNo = 5, RegNo = 10052, RegDate = DateTime.Now, Name = "Saravanan", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });

            viewModel.PaidMembers = paidMembers;
            return View(viewModel);
        }

        public async Task<IActionResult> AllMembers()
        {
            var List = await _context.Profiles.Include(s=>s.Caste).Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).ToListAsync();
            AdminAllMemberViewModel viewModel = new AdminAllMemberViewModel();
            List<TotalMember> totalMembers = new List<TotalMember>();
            int SNo = 1;
            foreach(var profile in List)
            {
                TotalMember totalMember = ConvertProfileToAllMember(profile);
                totalMember.SNo = SNo;
                totalMembers.Add(totalMember);
                SNo = SNo + 1;
            }
            viewModel.TotalMembers = totalMembers;

            return View(viewModel);
        }
        private TotalMember ConvertProfileToAllMember(Profile profile)
        {
            TotalMember totalMember = new TotalMember();
            totalMember.ProfileMasterId = profile.ProfileMasterId;
            totalMember.RegDate = profile.RegisteredDate;
            totalMember.Name = profile.Name;
            if (profile.Caste != null)
            {
                totalMember.Caste = profile.Caste.CasteName;
            }
                
            if(profile.ProfileEducation!=null)
                totalMember.Qualification = profile.ProfileEducation.EducationName;

            totalMember.Place = "Thiruvanamalai";
            totalMember.MonthlyRevenue = profile.MonthlyRevenue.Value;
            return totalMember;
        }

        public IActionResult CreateProfile()
        {
            
            ProfileViewModel viewModel = new ProfileViewModel();

            PopulateProfileViewModel(viewModel);

            return View(viewModel);


        }


        [HttpPost]
        public async Task<IActionResult> CreateProfile(ProfileViewModel model)
        {
            if(ModelState.IsValid)
            {



                Profile ProfileDbModel = ProfileViewModelToModel(model);
                
                ProfileDbModel.ProfileMasterId = Guid.NewGuid();
                

                _context.Add(ProfileDbModel);
                await _context.SaveChangesAsync();
              
            }
           
            PopulateProfileViewModel(model);

            return View(model);

        }
        private void PopulateProfileViewModel(ProfileViewModel viewModel)
        {
            viewModel.MaritalStatusMasters = _context.MaritalStatusMasters.ToList();
            viewModel.Educations = _context.EducationMasters.ToList();
            viewModel.EmployeedInLst = _context.EmployeedInMasters.ToList();

            //Religion Details
            viewModel.Religions = _context.ReligionMasters.ToList();
            viewModel.MotherTongues = _context.MotherTongueMasters.ToList();
            viewModel.Castes = _context.CasteMasters.ToList();
            viewModel.SubCastes = _context.SubCasteMasters.ToList();
            viewModel.Gothrams = _context.GothramMasters.ToList();

            //Family Information
            viewModel.FamilyStatuses = _context.FamilyStatusMasters.ToList();
            viewModel.FamilyTypes = _context.FamilyTypeMasters.ToList();
            viewModel.FamilyValues = _context.FamilyValuesMasters.ToList();

            viewModel.Countries = new List<SelectListItem>();
            foreach (var country in _context.CountryMasters)
            {
                viewModel.Countries.Add(new SelectListItem { Text = country.CountryName, Value = country.CountryMasterId.ToString() });
            }


            viewModel.States = new List<SelectListItem>();
            foreach (var item in _context.StateMasters)
            {
                viewModel.States.Add(new SelectListItem { Text = item.StateName, Value = item.StateMasterId.ToString() });
            }


            viewModel.Cities = new List<SelectListItem>();
            foreach (var item in _context.CityMasters)
            {
                viewModel.Cities.Add(new SelectListItem { Text = item.CityName, Value = item.CityMasterId.ToString() });
            }
        }
        private Profile ProfileViewModelToModel(ProfileViewModel model)
        {
            var ProfileDbModel = new Profile();
            ProfileDbModel.Name = model.Name;
            ProfileDbModel.Gender = model.Gender;
            ProfileDbModel.DateandTimeOfBirth = model.DateandTimeOfBirth;
            ProfileDbModel.MaritalStatusMasterId = model.MaritalStatusMasterId == "" || model.MaritalStatusMasterId == "0" ? null : Convert.ToInt32(model.MaritalStatusMasterId);
            ProfileDbModel.BodyType = model.BodyType;
            ProfileDbModel.Weight = model.Weight;
            ProfileDbModel.Height = model.Height;
            ProfileDbModel.SkinColor = model.SkinColor;
            ProfileDbModel.DisabilityDescription = model.DisabilityDescription;

            ProfileDbModel.EatingHabit = model.EatingHabit;
            ProfileDbModel.Drinking = model.Drinking;
            ProfileDbModel.Smoking = model.Smoking;

            ProfileDbModel.ProfileEducationMasterId = ConvertToId(model.HigherEducationsId);

            ProfileDbModel.ReligionMasterId = ConvertToId(model.ReligionMasterId);
            ProfileDbModel.MotherTongueMasterId = ConvertToId(model.MotherTongueMasterId);
            ProfileDbModel.CasteMasterId = ConvertToId(model.CasteMasterId);
            ProfileDbModel.SubCasteMasterId = ConvertToId(model.SubCasteMasterId);
            ProfileDbModel.GothramMasterId = ConvertToId(model.GothramMasterId);

            ProfileDbModel.EmployeedInMasterId = ConvertToId(model.EmployeedInMasterId);
            ProfileDbModel.MonthlyRevenue = model.MonthlyRevenue;
            ProfileDbModel.WorkingAddress = model.WorkingAddress;

            ProfileDbModel.Star = model.Star;
            ProfileDbModel.Rasi = model.Rasi;
            ProfileDbModel.Lagnam = model.Lagnam;
            ProfileDbModel.TimeofBirth = model.TimeofBirth;
            ProfileDbModel.PlaceOfBirth = model.PlaceOfBirth;

            ProfileDbModel.FamilyStatusMasterId = ConvertToId(model.FamilyStatusMasterId);
            ProfileDbModel.FamilyTypeMasterId = ConvertToId(model.FamilyTypeMasterId);
            ProfileDbModel.FamilyValuesMasterId = ConvertToId(model.FamilyValuesMasterId);
            ProfileDbModel.FatherName = model.FatherName;
            ProfileDbModel.FatherQualification = model.FatherQualification;
            ProfileDbModel.FatherJob = model.FatherJob;
            ProfileDbModel.MotherName = model.MotherName;
            ProfileDbModel.MotherQualification = model.MotherQualification;
            ProfileDbModel.MotherJob = model.MotherJob;
            ProfileDbModel.NativeDistrict = model.NativeDistrict;
            ProfileDbModel.ContactPerson = model.ContactPerson;
            ProfileDbModel.PhoneNo = model.PhoneNo;
            ProfileDbModel.MobileNo = model.MobileNo;
            ProfileDbModel.EmailId = model.EmailId;
            ProfileDbModel.BirthNumberinFamily = model.BirthNumberinFamily;
            ProfileDbModel.Brothers = model.Brothers;
            ProfileDbModel.MarriedBrothers = model.MarriedBrothers;
            ProfileDbModel.Sisters = model.Sisters;
            ProfileDbModel.MarriedSisters = model.MarriedSisters;

            ProfileDbModel.FromAge = model.FromAge;
            ProfileDbModel.UptoAge = model.UptoAge;

            return ProfileDbModel;

        }
        private ProfileViewModel ProfileModelToViewModel(Profile model)
        {
            var ProfileVM = new ProfileViewModel();
            ProfileVM.MatrimonyProfileId = model.ProfileMasterId;
            ProfileVM.Name = model.Name;
            ProfileVM.Gender = model.Gender;
            ProfileVM.DateandTimeOfBirth = model.DateandTimeOfBirth;
            ProfileVM.MaritalStatusMasterId = model.MaritalStatusMasterId.ToString();
            ProfileVM.BodyType = model.BodyType;
            ProfileVM.Weight = model.Weight;
            ProfileVM.Height = model.Height;
            ProfileVM.SkinColor = model.SkinColor;
            ProfileVM.DisabilityDescription = model.DisabilityDescription;

            ProfileVM.EatingHabit = model.EatingHabit;
            ProfileVM.Drinking = model.Drinking;
            ProfileVM.Smoking = model.Smoking;

            ProfileVM.HigherEducationsId = model.ProfileEducationMasterId.ToString();

            ProfileVM.ReligionMasterId = model.ReligionMasterId.ToString();
            ProfileVM.MotherTongueMasterId = model.MotherTongueMasterId.ToString();
            ProfileVM.CasteMasterId = model.CasteMasterId.ToString();
            ProfileVM.SubCasteMasterId = model.SubCasteMasterId.ToString();
            ProfileVM.GothramMasterId = model.GothramMasterId.ToString();

            ProfileVM.EmployeedInMasterId = model.EmployeedInMasterId.ToString();
            ProfileVM.MonthlyRevenue = model.MonthlyRevenue.Value;
            ProfileVM.WorkingAddress = model.WorkingAddress;

            ProfileVM.Star = model.Star;
            ProfileVM.Rasi = model.Rasi;
            ProfileVM.Lagnam = model.Lagnam;
            ProfileVM.TimeofBirth = model.TimeofBirth;
            ProfileVM.PlaceOfBirth = model.PlaceOfBirth;

            ProfileVM.FamilyStatusMasterId = model.FamilyStatusMasterId.ToString();
            ProfileVM.FamilyTypeMasterId = model.FamilyTypeMasterId.ToString();
            ProfileVM.FamilyValuesMasterId = model.FamilyValuesMasterId.ToString();
            ProfileVM.FatherName = model.FatherName;
            ProfileVM.FatherQualification = model.FatherQualification;
            ProfileVM.FatherJob = model.FatherJob;
            ProfileVM.MotherName = model.MotherName;
            ProfileVM.MotherQualification = model.MotherQualification;
            ProfileVM.MotherJob = model.MotherJob;
            ProfileVM.NativeDistrict = model.NativeDistrict;
            ProfileVM.ContactPerson = model.ContactPerson;
            ProfileVM.PhoneNo = model.PhoneNo;
            ProfileVM.MobileNo = model.MobileNo;
            ProfileVM.EmailId = model.EmailId;
            ProfileVM.BirthNumberinFamily = model.BirthNumberinFamily;
            ProfileVM.Brothers = model.Brothers;
            ProfileVM.MarriedBrothers = model.MarriedBrothers;
            ProfileVM.Sisters = model.Sisters;
            ProfileVM.MarriedSisters = model.MarriedSisters;

            ProfileVM.FromAge = model.FromAge;
            ProfileVM.UptoAge = model.UptoAge;

            if(model.User!=null)
            { 
                ProfileVM.LoginEMailId = model.User.UserName;
                ProfileVM.HavingLogin = true;
            }
            else
            {
                ProfileVM.HavingLogin = false; 
            }
            return ProfileVM;

        }
        public async Task<IActionResult> EditProfile(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            _context.Entry(profile).Reference("User").Load();
            ProfileViewModel viewModel = new ProfileViewModel();

            viewModel = ProfileModelToViewModel(profile);
            #region LoadComboxbox
            viewModel.MaritalStatusMasters = _context.MaritalStatusMasters.ToList();
            viewModel.Educations = _context.EducationMasters.ToList();
            viewModel.EmployeedInLst = _context.EmployeedInMasters.ToList();

            //Religion Details
            viewModel.Religions = _context.ReligionMasters.ToList();
            viewModel.MotherTongues = _context.MotherTongueMasters.ToList();
            viewModel.Castes = _context.CasteMasters.ToList();
            viewModel.SubCastes = _context.SubCasteMasters.ToList();
            viewModel.Gothrams = _context.GothramMasters.ToList();

            //Family Information
            viewModel.FamilyStatuses = _context.FamilyStatusMasters.ToList();
            viewModel.FamilyTypes = _context.FamilyTypeMasters.ToList();
            viewModel.FamilyValues = _context.FamilyValuesMasters.ToList();
            #endregion




            return View("CreateProfile",viewModel);
        }

        // POST: CasteMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(Guid id,ProfileViewModel model)
        {
            if (id != model.MatrimonyProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Profile dbModel = ProfileViewModelToModel(model);

                    _context.Update(dbModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CasteMasterExists(casteMaster.CasteMasterId))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> SendUserName(ProfileViewModel model, [FromServices] IEmailSender emailSender,[FromServices] UserManager<ApplicationUser> userManager)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.ProfileMasterId == model.MatrimonyProfileId);
            if (profile != null)
            {
                var user = new ApplicationUser { UserName = model.LoginEMailId, Email = model.LoginEMailId };
                string password = GenerateRandomPassword();
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "MatrimonyUser");

                    profile.UserId = user.Id;
                    _context.Update(profile);
                    await _context.SaveChangesAsync();

                    await emailSender.SendEmailAsync(model.LoginEMailId, "addon confirmation email check", GenerateRandomPassword());
                }
            }

            PopulateProfileViewModel(model);
            return View("CreateProfile", model);
        }
            public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        private int? ConvertToId(string data)
        {
            int result;
            if (data == "" || data == "0")
                return null;
            else if (Int32.TryParse(data, out result))
                return result;
            else
                return null;
        }
    }
}
