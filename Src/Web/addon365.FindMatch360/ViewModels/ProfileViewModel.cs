using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class ProfileViewModel
    {
       
        public Guid MatrimonyProfileId { get; set; }

        #region Person basic Details
        public String Name { get; set; }
        public byte Gender { get; set; }
        public DateTime DateandTimeOfBirth { get; set; }
        public int MaritalStatusMasterId { get; set; }
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
     
        public int ProfileEducationsId { get; set; }
        public IEnumerable<ProfileEducations> ProfileEducations { get; set; }

        #endregion

        #region JobDetails
        
        public int EmployeedInMasterId { get; set; }
        public EmployeedInMaster EmployeedIn { get; set; }
        public string WorkingAddress { get; set; }
        public string MonthlyRevenue { get; set; }
        #endregion

        #region ReligionDetails
     
        public int ReligionMasterId { get; set; }
        public IEnumerable<ReligionMaster> Religions { get; set; }

        public int MotherTongueMasterId { get; set; }
        public IEnumerable<MotherTongueMaster> MotherTongues { get; set; }
        public int CasteMasterId { get; set; }
        public IEnumerable<CasteMaster> Castes { get; set; }
        public int SubCasteMasterId { get; set; }
        public IEnumerable<SubCasteMaster> SubCastes { get; set; }
        public int GothramMasterId { get; set; }
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

        public int FamilyStatusMasterId { get; set; }
        public IEnumerable<FamilyStatusMaster> FamilyStatuses { get; set; }
        public int FamilyTypeMasterId { get; set; }
        public IEnumerable<FamilyTypeMaster> FamilyTypes { get; set; }
        public int FamilyValuesMasterId { get; set; }
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
        public int PreferenceReligionMasterId { get; set; }
        public int PreferenceMotherTongueMasterId { get; set; }
        public int PreferenceCasteMasterId { get; set; }
        public int PreferenceSubCasteMasterId { get; set; }
        public string PreferenceStar { get; set; }
        public string PreferenceRasi { get; set; }
        public string PreferenceChavvaiDosham { get; set; }
        public string PreferenceQualification { get; set; }

        #endregion
    }
}
