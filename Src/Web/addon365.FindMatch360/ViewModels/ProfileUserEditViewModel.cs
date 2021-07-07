using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class ProfileUserEditViewModel
    {

        public Guid ProfileId { get; set; }

        #region Person basic Details
        public String Name { get; set; }
        //https://www.youtube.com/watch?v=QpJvqiHl1Fo 
        public byte Gender { get; set; }
        public DateTime DateandTimeOfBirth { get; set; }
        public string? MaritalStatusMasterId { get; set; }
        public IEnumerable<MaritalStatusMaster> MaritalStatusMasters { get; set; }
        public byte BodyType { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string SkinColor { get; set; }
        public Boolean AnyDisability { get; set; }
        public string DisabilityDescription { get; set; }
        #endregion

        #region Life style
        public byte EatingHabit { get; set; }
        public byte Drinking { get; set; }
        public byte Smoking { get; set; }
        #endregion

        #region Education Details

        public string HigherEducationsId { get; set; }
        public string EducationName { get; set; }
        public IEnumerable<EducationMaster> Educations { get; set; }

        #endregion

        #region JobDetails

        public string EmployeedInMasterId { get; set; }
        public string EmployeedInName { get; set; }
        public IEnumerable<EmployeedInMaster> EmployeedInLst { get; set; }

        public string OccupationMasterId { get; set; }
        public string OccupationName { get; set; }
        public IEnumerable<OccupationMaster> Occupations { get; set; }
        public string WorkingAddress { get; set; }
        public string MonthlyRevenue { get; set; }
        #endregion

        #region ReligionDetails

        public string ReligionMasterId { get; set; }
        public string ReligioName { get; set; }
        public IEnumerable<ReligionMaster> Religions { get; set; }

        public string MotherTongueMasterId { get; set; }
        public string MotherTongueName { get; set; }
        public IEnumerable<MotherTongueMaster> MotherTongues { get; set; }
        public string CasteMasterId { get; set; }
        public string CasteName { get; set; }
        public IEnumerable<CasteMaster> Castes { get; set; }
        public string SubCasteMasterId { get; set; }
        public string SubCasteName { get; set; }
        public IEnumerable<SubCasteMaster> SubCastes { get; set; }
        public string GothramMasterId { get; set; }
        public IEnumerable<GothramMaster> Gothrams { get; set; }
        #endregion

        #region Horoscope Details
        public string Star { get; set; }
        public string Rasi { get; set; }
        public string Lagnam { get; set; }
        public string TimeofBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        #endregion

        #region Family Information

        public string FamilyStatusMasterId { get; set; }
        public string FamilyStatusName { get; set; }
        public IEnumerable<FamilyStatusMaster> FamilyStatuses { get; set; }
        public string FamilyTypeMasterId { get; set; }
        public string FamilyTypeName { get; set; }
        public IEnumerable<FamilyTypeMaster> FamilyTypes { get; set; }
        public string FamilyValuesMasterId { get; set; }
        public string FamilyValueName { get; set; }
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
        public string MobileNo { get; set; }
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
    }

    public static class ProfileUserEditViewModelExtensions
    {
        public static Profile ConvertToProfile(this ProfileUserEditViewModel viewModel)
        {
            Profile profile = new Profile();

            profile.ProfileMasterId = viewModel.ProfileId;
            profile.Name = viewModel.Name;
            
            return profile;
        }
    }
}