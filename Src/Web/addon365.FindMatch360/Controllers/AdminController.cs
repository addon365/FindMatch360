using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
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


        public IActionResult CreateProfile()
        {
            
            ProfileViewModel viewModel = new ProfileViewModel();

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


            return View(viewModel);
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfile(ProfileViewModel model)
        {
            if(ModelState.IsValid)
            {
                var ProfileDbModel = new Profile
                {
                    MatrimonyProfileId = Guid.NewGuid(),
                    Name = model.Name,
                    Gender = model.Gender
                 
            };
                _context.Add(ProfileDbModel);
                await _context.SaveChangesAsync();
              
            }


            return View(model);

        }
    }
}
