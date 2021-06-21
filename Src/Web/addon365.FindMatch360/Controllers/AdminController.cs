﻿using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public AdminController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var PaidList = await _context.Profiles.Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).ToListAsync();
            return View();
        }


        public async Task <IActionResult> PaidList()
        {
            var PaidList = await _context.Profiles.Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).ToListAsync();
            return View(PaidList);
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

                var ProfileDbModel = new Profile();


                ProfileDbModel.ProfileMasterId = Guid.NewGuid();
                ProfileDbModel.Name = model.Name;
                ProfileDbModel.Gender = model.Gender;
                ProfileDbModel.DateandTimeOfBirth = model.DateandTimeOfBirth;
                ProfileDbModel.MaritalStatusMasterId=model.MaritalStatusMasterId == "" || model.MaritalStatusMasterId=="0" ?null : Convert.ToInt32(model.MaritalStatusMasterId);
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
                

                _context.Add(ProfileDbModel);
                await _context.SaveChangesAsync();
              
            }
            model.MaritalStatusMasters = _context.MaritalStatusMasters.ToList();
            model.Educations = _context.EducationMasters.ToList();
            model.EmployeedInLst = _context.EmployeedInMasters.ToList();

            //Religion Details
            model.Religions = _context.ReligionMasters.ToList();
            model.MotherTongues = _context.MotherTongueMasters.ToList();
            model.Castes = _context.CasteMasters.ToList();
            model.SubCastes = _context.SubCasteMasters.ToList();
            model.Gothrams = _context.GothramMasters.ToList();

            //Family Information
            model.FamilyStatuses = _context.FamilyStatusMasters.ToList();
            model.FamilyTypes = _context.FamilyTypeMasters.ToList();
            model.FamilyValues = _context.FamilyValuesMasters.ToList();


            return View(model);

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
