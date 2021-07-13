using addon365.FindMatch360.Data;
using addon365.FindMatch360.Helpers;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    //[Authorize(Roles = "Administrator,User")]
    public class AdminController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static int _catId;
        private static int _subId;
        public AdminController(ilamaiMatrimonyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this._webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            var profiles = _context.Profiles.Where(s => DbF.DateDiffDay(System.DateTime.Now.Date,s.RegisteredDate.Date)== 0).Include(s => s.Caste).Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).Select(s => new RecentMember()
            {
                
                RegDate = s.RegisteredDate,
                Name = s.Name,
                Caste = s.Caste != null ? s.Caste.CasteName : string.Empty,
                Qualification = s.ProfileEducation != null ? s.ProfileEducation.EducationName : string.Empty,
                Place = s.PlaceOfBirth,
                Job = s.EmployeedIn != null ? s.EmployeedIn.EmployeedInName : string.Empty,
                Salary = s.MonthlyRevenue != null ? s.MonthlyRevenue.Value : 0
            });
            AdminDashBoardViewModel viewModel = new AdminDashBoardViewModel();
            viewModel.TotalMembers = _context.Profiles.Count();
            viewModel.PaidMembers = _context.ProfileRenewals.Count();
            viewModel.InactiveMembers = viewModel.TotalMembers-viewModel.PaidMembers;
            viewModel.Visitors = 10;

            //List<RecentMember> recentMembers = new List<RecentMember>();
            //recentMembers.Add(new RecentMember { SNo = 1, RegNo = 10048, RegDate = DateTime.Now, Name = "Santhosh", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            //recentMembers.Add(new RecentMember { SNo = 2, RegNo = 10049, RegDate = DateTime.Now, Name = "Ramesh", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            //recentMembers.Add(new RecentMember { SNo = 3, RegNo = 10050, RegDate = DateTime.Now, Name = "Sarath", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            //recentMembers.Add(new RecentMember { SNo = 4, RegNo = 10051, RegDate = DateTime.Now, Name = "Lakshmi", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });
            //recentMembers.Add(new RecentMember { SNo = 5, RegNo = 10052, RegDate = DateTime.Now, Name = "Saravanan", Caste = "Vanniyar", Job = "Software", Qualification = "BE", Place = "Thiruvanamalai", Salary = 13000 });

            viewModel.RecentMembers = profiles.ToList();

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

        public async Task<IActionResult> AllMembers(string sortOrder,
    string currentFilter,
    string searchString,
    string fromDate,
    string toDate,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["FromDate"] = fromDate;
            ViewData["ToDate"] = toDate;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //Func<Profile, TotalMember> func = ConvertProfileToAllMember;
            // var profiles = _context.Profiles.Include(s => s.Caste).Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).Select(s=> func(s));

            var profiles = _context.Profiles.Include(s => s.Caste).Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).Select(s => new TotalMember()
            {
                ProfileMasterId = s.ProfileMasterId,
                RegDate = s.RegisteredDate,
                ProfileName = s.Name,
                Caste = s.Caste != null ? s.Caste.CasteName : string.Empty,
                Qualification = s.ProfileEducation != null ? s.ProfileEducation.EducationName : string.Empty,
                Place = s.PlaceOfBirth,
                Job = s.EmployeedIn != null ? s.EmployeedIn.EmployeedInName : string.Empty,
                MonthlyRevenue = s.MonthlyRevenue != null ? s.MonthlyRevenue.Value:0
            }) ;

            if (fromDate != null && toDate != null)
            {
                DateTime FromD = Convert.ToDateTime(fromDate);
                DateTime ToD = Convert.ToDateTime(toDate);
                if (!String.IsNullOrEmpty(searchString))
                {
                    profiles = profiles.Where(s => s.ProfileName.Contains(searchString) && s.RegDate.Date>= FromD.Date && s.RegDate.Date<= ToD.Date);
                }
                else
                {
                    profiles = profiles.Where(s => s.RegDate.Date >= FromD.Date && s.RegDate.Date <= ToD.Date);
                }

            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.ProfileName.Contains(searchString));
            }
           
            switch (sortOrder)
            {
                case "name_desc":
                    profiles = profiles.OrderByDescending(s => s.ProfileName);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    profiles = profiles.OrderBy(s => s.ProfileName);
                    break;
            }
            AdminAllMemberViewModel viewModel = new AdminAllMemberViewModel();
            //List<TotalMember> totalMembers = new List<TotalMember>();
            //int SNo = 1;

            //foreach(var profile in profiles)
            //{
            //    TotalMember totalMember = ConvertProfileToAllMember(profile);
            //    totalMember.SNo = SNo;
            //    totalMembers.Add(totalMember);
            //    SNo = SNo + 1;
            //}
            //viewModel.TotalMembers = totalMembers;
            int pageSize = 3;
            viewModel.TotalMembers = await PaginatedList<TotalMember>.CreateAsync(profiles.AsNoTracking(), pageNumber ?? 1, pageSize);
            return View(viewModel);
        }
        
        private TotalMember ConvertProfileToAllMember(Profile profile)
        {
            TotalMember totalMember = new TotalMember();
            totalMember.ProfileMasterId = profile.ProfileMasterId;
            totalMember.RegDate = profile.RegisteredDate;
            totalMember.ProfileName = profile.Name;
            //if (profile.Caste != null)
            //{
            //    totalMember.Caste = profile.Caste.CasteName;
            //}
                
            //if(profile.ProfileEducation!=null)
            //    totalMember.Qualification = profile.ProfileEducation.EducationName;

            //totalMember.Place = "Thiruvanamalai";
            //totalMember.MonthlyRevenue = profile.MonthlyRevenue.Value;
            return totalMember;
        }

        public IActionResult CreateProfile()
        {
            
            AdminProfileCreateViewModel viewModel = new AdminProfileCreateViewModel();

            PopulateProfileViewModel(viewModel);

            return View(viewModel);


        }


        [HttpPost]
        public async Task<IActionResult> CreateProfile(AdminProfileCreateViewModel model)
        {
            if(ModelState.IsValid)
            {



                Profile ProfileDbModel = ProfileCreateViewModelToModel(model);
                
                ProfileDbModel.ProfileMasterId = Guid.NewGuid();
                if (_context.Profiles.Count() > 0)
                {
                    ProfileDbModel.RegistrationNo = (_context.Profiles.Max(p => Convert.ToInt64(p.RegistrationNo)) + 1).ToString();
                }
                else
                {
                    ProfileDbModel.RegistrationNo = "1";
                }

                if (model.ImageFile != null)
                {



                    string wwwRooPath = _webHostEnvironment.WebRootPath;
                    string fileName = "Pri_";
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    model.ImageName = fileName = fileName + ProfileDbModel.ProfileMasterId + extension;
                    string path = Path.Combine(wwwRooPath + "/ProfilePhotos/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(fileStream);
                    }
                    ProfileDbModel.PhotoName = model.ImageName;


                }

                _context.Add(ProfileDbModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AllMembers));

            }
           
            PopulateProfileViewModel(model);

            return View(model);

        }
        private void PopulateProfileViewModel(AdminProfileCreateViewModel viewModel)
        {
            viewModel.MaritalStatusMasters = _context.MaritalStatusMasters.ToList();
            //viewModel.Educations = _context.EducationMasters.ToList();
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
            var Rasis = _context.RasiMasters.Select(s => new SelectListItem() { Text = s.RasiName, Value = s.RasiMasterId.ToString() });
            if (Rasis.Count() > 0)
            {
                viewModel.Rasis = new List<SelectListItem>();
                viewModel.Rasis.AddRange(Rasis.ToList());
            }
            viewModel.Stars = new List<SelectListItem>();
            viewModel.Stars.AddRange(_context.StarMasters.Select(s => new SelectListItem() { Text = s.StarName, Value = s.StarMasterId.ToString() }).ToList());

            viewModel.Lagnams = new List<SelectListItem>();
            viewModel.Lagnams.AddRange(_context.LagnamMasters.Select(s => new SelectListItem() { Text = s.LagnamName, Value = s.LagnamMasterId.ToString() }).ToList());
        }
        private Profile ProfileCreateViewModelToModel(AdminProfileCreateViewModel model)
        {
            var ProfileDbModel = new Profile();
            ProfileDbModel.Name = model.Name;

           

            ProfileDbModel.LastName = model.LastName;
            ProfileDbModel.Gender = model.Gender;
            ProfileDbModel.DateandTimeOfBirth = model.DateOfBirth;
            ProfileDbModel.MaritalStatusMasterId = model.MaritalStatusMasterId == "" || model.MaritalStatusMasterId == "0" ? null : Convert.ToInt32(model.MaritalStatusMasterId);
            ProfileDbModel.BodyType = model.BodyType;
            ProfileDbModel.Weight = model.Weight;
            ProfileDbModel.Height = model.Height;
            ProfileDbModel.SkinColor = model.SkinColor;
            ProfileDbModel.DisabilityDescription = model.DisabilityDescription;

            ProfileDbModel.EatingHabit = model.EatingHabit;
            ProfileDbModel.Drinking = model.Drinking;
            ProfileDbModel.Smoking = model.Smoking;

            ProfileDbModel.ProfileEducationDetail = model.EducationDetail;
            //ProfileDbModel.ProfileEducationMasterId = ConvertToId(model.HigherEducationsId);

            ProfileDbModel.ReligionMasterId = ConvertToId(model.ReligionMasterId);
            ProfileDbModel.MotherTongueMasterId = ConvertToId(model.MotherTongueMasterId);
            ProfileDbModel.CasteMasterId = ConvertToId(model.CasteMasterId);
            ProfileDbModel.SubCasteMasterId = ConvertToId(model.SubCasteMasterId);
            ProfileDbModel.GothramMasterId = ConvertToId(model.GothramMasterId);

            ProfileDbModel.EmployeedInMasterId = ConvertToId(model.EmployeedInMasterId);
            ProfileDbModel.MonthlyRevenue = model.MonthlyRevenue;
            ProfileDbModel.WorkingAddress = model.WorkingAddress;

            ProfileDbModel.StarId = ConvertToId(model.StarId);
            ProfileDbModel.RasiId = ConvertToId(model.RasiId);
            ProfileDbModel.LagnamId = ConvertToId(model.LagnamId);
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
        private Profile ProfileEditViewModelToModel(AdminProfileEditViewModel model)
        {
            var ProfileDbModel = new Profile();
            ProfileDbModel.ProfileMasterId = model.MatrimonyProfileId;
            ProfileDbModel.Name = model.Name;
            ProfileDbModel.Gender = model.Gender;
            ProfileDbModel.DateandTimeOfBirth = model.DateOfBirth;
            ProfileDbModel.MaritalStatusMasterId = model.MaritalStatusMasterId == "" || model.MaritalStatusMasterId == "0" ? null : Convert.ToInt32(model.MaritalStatusMasterId);
            ProfileDbModel.BodyType = model.BodyType;
            ProfileDbModel.Weight = model.Weight;
            ProfileDbModel.Height = model.Height;
            ProfileDbModel.SkinColor = model.SkinColor;
            ProfileDbModel.DisabilityDescription = model.DisabilityDescription;

            ProfileDbModel.EatingHabit = model.EatingHabit;
            ProfileDbModel.Drinking = model.Drinking;
            ProfileDbModel.Smoking = model.Smoking;

            //ProfileDbModel.ProfileEducationMasterId = ConvertToId(model.HigherEducationsId);
            ProfileDbModel.ProfileEducationDetail = model.EducationDetail;

            ProfileDbModel.ReligionMasterId = ConvertToId(model.ReligionMasterId);
            ProfileDbModel.MotherTongueMasterId = ConvertToId(model.MotherTongueMasterId);
            ProfileDbModel.CasteMasterId = ConvertToId(model.CasteMasterId);
            ProfileDbModel.SubCasteMasterId = ConvertToId(model.SubCasteMasterId);
            ProfileDbModel.GothramMasterId = ConvertToId(model.GothramMasterId);

            ProfileDbModel.EmployeedInMasterId = ConvertToId(model.EmployeedInMasterId);
            ProfileDbModel.MonthlyRevenue = model.MonthlyRevenue;
            ProfileDbModel.WorkingAddress = model.WorkingAddress;

            ProfileDbModel.StarId = ConvertToId(model.StarId);
            ProfileDbModel.RasiId = ConvertToId(model.RasiId);
            ProfileDbModel.LagnamId = ConvertToId(model.LagnamId);
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
        //private AdminProfileCreateViewModel ProfileModelToCreateViewModel(Profile model)
        //{
        //    var ProfileVM = new AdminProfileCreateViewModel();
        //    ProfileVM.MatrimonyProfileId = model.ProfileMasterId;
        //    ProfileVM.Name = model.Name;
        //    ProfileVM.Gender = model.Gender;
        //    ProfileVM.DateandTimeOfBirth = model.DateandTimeOfBirth;
        //    ProfileVM.MaritalStatusMasterId = model.MaritalStatusMasterId.ToString();
        //    ProfileVM.BodyType = model.BodyType;
        //    ProfileVM.Weight = model.Weight;
        //    ProfileVM.Height = model.Height;
        //    ProfileVM.SkinColor = model.SkinColor;
        //    ProfileVM.DisabilityDescription = model.DisabilityDescription;

        //    ProfileVM.EatingHabit = model.EatingHabit;
        //    ProfileVM.Drinking = model.Drinking;
        //    ProfileVM.Smoking = model.Smoking;

        //    ProfileVM.HigherEducationsId = model.ProfileEducationMasterId.ToString();

        //    ProfileVM.ReligionMasterId = model.ReligionMasterId.ToString();
        //    ProfileVM.MotherTongueMasterId = model.MotherTongueMasterId.ToString();
        //    ProfileVM.CasteMasterId = model.CasteMasterId.ToString();
        //    ProfileVM.SubCasteMasterId = model.SubCasteMasterId.ToString();
        //    ProfileVM.GothramMasterId = model.GothramMasterId.ToString();

        //    ProfileVM.EmployeedInMasterId = model.EmployeedInMasterId.ToString();
        //    ProfileVM.MonthlyRevenue = model.MonthlyRevenue.Value;
        //    ProfileVM.WorkingAddress = model.WorkingAddress;

        //    ProfileVM.Star = model.Star;
        //    ProfileVM.Rasi = model.Rasi;
        //    ProfileVM.Lagnam = model.Lagnam;
        //    ProfileVM.TimeofBirth = model.TimeofBirth;
        //    ProfileVM.PlaceOfBirth = model.PlaceOfBirth;

        //    ProfileVM.FamilyStatusMasterId = model.FamilyStatusMasterId.ToString();
        //    ProfileVM.FamilyTypeMasterId = model.FamilyTypeMasterId.ToString();
        //    ProfileVM.FamilyValuesMasterId = model.FamilyValuesMasterId.ToString();
        //    ProfileVM.FatherName = model.FatherName;
        //    ProfileVM.FatherQualification = model.FatherQualification;
        //    ProfileVM.FatherJob = model.FatherJob;
        //    ProfileVM.MotherName = model.MotherName;
        //    ProfileVM.MotherQualification = model.MotherQualification;
        //    ProfileVM.MotherJob = model.MotherJob;
        //    ProfileVM.NativeDistrict = model.NativeDistrict;
        //    ProfileVM.ContactPerson = model.ContactPerson;
        //    ProfileVM.PhoneNo = model.PhoneNo;
        //    ProfileVM.MobileNo = model.MobileNo;
        //    ProfileVM.EmailId = model.EmailId;
        //    ProfileVM.BirthNumberinFamily = model.BirthNumberinFamily;
        //    ProfileVM.Brothers = model.Brothers;
        //    ProfileVM.MarriedBrothers = model.MarriedBrothers;
        //    ProfileVM.Sisters = model.Sisters;
        //    ProfileVM.MarriedSisters = model.MarriedSisters;

        //    ProfileVM.FromAge = model.FromAge;
        //    ProfileVM.UptoAge = model.UptoAge;

        //    if(model.User!=null)
        //    { 
        //        ProfileVM.LoginEMailId = model.User.UserName;
        //        ProfileVM.HavingLogin = true;
        //    }
        //    else
        //    {
        //        ProfileVM.HavingLogin = false; 
        //    }
        //    return ProfileVM;

        //}
        private AdminProfileEditViewModel ProfileModelToEditViewModel(Profile model)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            var ProfileVM = new AdminProfileEditViewModel();
            ProfileVM.MatrimonyProfileId = model.ProfileMasterId;
            ProfileVM.Name = model.Name;
            if (System.IO.File.Exists(Path.Combine(webRootPath, "ProfilePhotos/Pri_" + model.ProfileMasterId + ".jpg")))
            {
                ProfileVM.PhotoUrl = "/ProfilePhotos/Pri_" + model.ProfileMasterId + ".jpg";
            }
            else
            {
                ProfileVM.PhotoUrl = "~/images/profile_pic.png";
            }
            ProfileVM.LastName = model.LastName;
            ProfileVM.Gender = model.Gender;
            ProfileVM.DateOfBirth = model.DateandTimeOfBirth;
            ProfileVM.MaritalStatusMasterId = model.MaritalStatusMasterId.ToString();
            ProfileVM.BodyType = model.BodyType;
            ProfileVM.Weight = model.Weight;
            ProfileVM.Height = model.Height;
            ProfileVM.SkinColor = model.SkinColor;
            ProfileVM.DisabilityDescription = model.DisabilityDescription;

            ProfileVM.EatingHabit = model.EatingHabit;
            ProfileVM.Drinking = model.Drinking;
            ProfileVM.Smoking = model.Smoking;

            //ProfileVM.HigherEducationsId = model.ProfileEducationMasterId.ToString();
            ProfileVM.EducationDetail = model.ProfileEducationDetail;

            ProfileVM.ReligionMasterId = model.ReligionMasterId.ToString();
            ProfileVM.MotherTongueMasterId = model.MotherTongueMasterId.ToString();
            ProfileVM.CasteMasterId = model.CasteMasterId.ToString();
            ProfileVM.SubCasteMasterId = model.SubCasteMasterId.ToString();
            ProfileVM.GothramMasterId = model.GothramMasterId.ToString();

            ProfileVM.EmployeedInMasterId = model.EmployeedInMasterId.ToString();
            ProfileVM.MonthlyRevenue = model.MonthlyRevenue==null?0: model.MonthlyRevenue.Value;
            ProfileVM.WorkingAddress = model.WorkingAddress;

            ProfileVM.StarId = model.StarId.ToString();
            ProfileVM.RasiId = model.RasiId.ToString();
            ProfileVM.LagnamId = model.LagnamId.ToString();

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

            if (model.User != null)
            {
                ProfileVM.LoginEMailId = model.User.UserName;
                
                if (ProfileVM.EmailId == "" || ProfileVM.EmailId==null)
                    ProfileVM.EmailId = ProfileVM.LoginEMailId;

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
            AdminProfileEditViewModel viewModel = new AdminProfileEditViewModel();
            viewModel.MatrimonyProfileId = profile.ProfileMasterId;
            viewModel = ProfileModelToEditViewModel(profile);
            #region LoadComboxbox
            PopulateEditViewModelComboBoxDetail(viewModel);
            #endregion




            return View(viewModel);
        }
        private void PopulateEditViewModelComboBoxDetail(AdminProfileEditViewModel viewModel)
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
        }
        // POST: CasteMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(Guid id, AdminProfileEditViewModel model)
        {
            if (id != model.MatrimonyProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Profile dbModel = ProfileEditViewModelToModel(model);

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
                return RedirectToAction(nameof(AllMembers));
            }
            PopulateEditViewModelComboBoxDetail(model);
            return View(model);
        }
        public async Task<IActionResult> SendUserName(AdminProfileCreateViewModel model, [FromServices] IEmailSender emailSender,[FromServices] UserManager<ApplicationUser> userManager)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.ProfileMasterId == model.MatrimonyProfileId);
            if (profile != null)
            {
                var user = new ApplicationUser { UserName = model.LoginEMailId, Email = model.LoginEMailId };
                string password = GeneralHelper.GenerateRandomPassword();
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "MatrimonyUser");

                    profile.UserId = user.Id;
                    _context.Update(profile);
                    await _context.SaveChangesAsync();

                    await emailSender.SendEmailAsync(model.LoginEMailId, "addon confirmation email check", password);
                }
            }

            PopulateProfileViewModel(model);
            return View("EditProfile", model);
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
