using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class AdminProfileEditViewModel
    {

        public Guid MatrimonyProfileId { get; set; }

        #region Person basic Details
        public String Name { get; set; }
        public string PhotoUrl { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
        public String LastName { get; set; }
        //https://www.youtube.com/watch?v=QpJvqiHl1Fo 
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string? MaritalStatusMasterId { get; set; }
        public IEnumerable<MaritalStatusMaster> MaritalStatusMasters { get; set; }
        public byte BodyType { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string SkinColor { get; set; }
        public Boolean AnyDisability { get; set; }
        public string DisabilityDescription { get; set; }
        public string CountryId { get; set; }
        public List<SelectListItem> Countries { get;set;}
        public string StateId { get; set; }
        public List<SelectListItem> States { get; set; }
        public string CityId { get; set; }
        public List<SelectListItem> Cities { get; set; }
        #endregion

        #region Life style
        public byte EatingHabit { get; set; }
        public byte Drinking { get; set; }
        public byte Smoking { get; set; }
        #endregion

        #region Education Details
     
        public string HigherEducationsId { get; set; }
        public IEnumerable<EducationMaster> Educations { get; set; }

        public string EducationDetail { get; set; }
        #endregion

        #region JobDetails

        public string EmployeedInMasterId { get; set; }
        public IEnumerable<EmployeedInMaster> EmployeedInLst { get; set; }

        public string OccupationMasterId { get; set; }
        public IEnumerable<OccupationMaster> Occupations { get; set; }
        public string WorkingAddress { get; set; }
        public decimal MonthlyRevenue { get; set; }
        #endregion

        #region ReligionDetails
     
        public string ReligionMasterId { get; set; }
        public IEnumerable<ReligionMaster> Religions { get; set; }

        public string MotherTongueMasterId { get; set; }
        public IEnumerable<MotherTongueMaster> MotherTongues { get; set; }
        public string CasteMasterId { get; set; }
        public IEnumerable<CasteMaster> Castes { get; set; }
        public string SubCasteMasterId { get; set; }
        public IEnumerable<SubCasteMaster> SubCastes { get; set; }
        public string GothramMasterId { get; set; }
        public IEnumerable<GothramMaster> Gothrams { get; set; }
        #endregion

        #region Horoscope Details
        public string StarId { get; set; }
        public List<SelectListItem> Stars { get; set; }
        public string RasiId { get; set; }
        public List<SelectListItem> Rasis { get; set; }
        public string LagnamId { get; set; }
        public List<SelectListItem> Lagnams { get; set; }
        public string TimeofBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        #endregion

        #region Family Information

        public string FamilyStatusMasterId { get; set; }
        public IEnumerable<FamilyStatusMaster> FamilyStatuses { get; set; }
        public string FamilyTypeMasterId { get; set; }
        public IEnumerable<FamilyTypeMaster> FamilyTypes { get; set; }
        public string FamilyValuesMasterId { get; set; }
        public IEnumerable<FamilyValuesMaster> FamilyValues { get; set; }
        public string FatherName { get; set; }
        public string FatherQualification { get; set; }
        public string FatherJob { get; set; }
        public string MotherName { get; set; }
        public string MotherQualification { get; set; }
        public string MotherJob { get; set; }
        public string NativeDistrict { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        public short BirthNumberinFamily { get; set; }
        public short Brothers { get; set; }
        public short MarriedBrothers { get; set; }
        public short Sisters { get; set; }
        public short MarriedSisters { get; set; }
        #endregion



        #region Preferences
        public byte FromAge { get; set; }
        public byte UptoAge { get; set; }


        #endregion

        #region Login
        public string LoginEMailId { get; set; }
        public bool HavingLogin { get; set; }
        #endregion
    }
}
