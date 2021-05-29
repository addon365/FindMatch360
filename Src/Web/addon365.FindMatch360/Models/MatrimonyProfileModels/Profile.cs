using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.FindMatch360.Models.MatrimonyProfileModels
{
    public class Profile
    {
        [Key]
        public Guid ProfileMasterId { get; set; }
        [ForeignKey("ProfileFor")]
        public int? ProfileForId { get; set; }
        public ProfileForMaster ProfileFor { get; set; }

        #region Person basic Details
        public String Name { get; set; }
        public string PhotoName { get; set; }
        public byte Gender { get; set; }
        public DateTime DateandTimeOfBirth { get; set; }

        [ForeignKey("MarriedStatus")]
        public int? MaritalStatusMasterId { get; set; }
        public MaritalStatusMaster MaritalStatus { get; set; }
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

        [ForeignKey("ProfileEducation")]
        public int? ProfileEducationMasterId { get; set; }
        public EducationMaster ProfileEducation { get; set; }
        public string ProfileEducationDetail { get; set; }
        #endregion

        #region JobDetails
        [ForeignKey("EmployeedIn")]
        public int? EmployeedInMasterId { get; set; }
        public EmployeedInMaster EmployeedIn { get; set; }

        [ForeignKey("Occupation")]
        public int? OccupationMasterId { get; set; }
        public OccupationMaster Occupation { get; set; }

        [ForeignKey("WorkingCountry")]
        public int? WorkingCountryMasterId { get; set; }
        public CountryMaster WorkingCountry { get; set; }

        [ForeignKey("WorkingState")]
        public int? WorkingStateMasterId { get; set; }
        public StateMaster WorkingState { get; set; }

        [ForeignKey("WorkingCity")]
        public int? WorkingCityMasterId { get; set; }
        public CityMaster WorkingCity { get; set; }

        public string WorkingAddress { get; set; }
        public string MonthlyRevenue { get; set; }
        #endregion

        #region ReligionDetails
        [ForeignKey("Religion")]
        public int? ReligionMasterId { get; set; }
        public ReligionMaster Religion { get; set; }

        [ForeignKey("MotherTongue")]
        public int? MotherTongueMasterId { get; set; }
        public MotherTongueMaster MotherTongue { get; set; }


        [ForeignKey("Caste")]
        public int? CasteMasterId { get; set; }
        public CasteMaster Caste { get; set; }

        [ForeignKey("SubCaste")]
        public int? SubCasteMasterId { get; set; }
        public SubCasteMaster SubCaste { get; set; }

        [ForeignKey("Gothram")]
        public int? GothramMasterId { get; set; }
        public GothramMaster Gothram { get; set; }

        #endregion

        #region Horoscope Details
        public string Star { get; set; }
        public string Rasi { get; set; }
        public string Lagnam { get; set; }
        public string TimeofBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        #endregion

        #region Family Information

        [ForeignKey("FamilyStatus")]
        public int? FamilyStatusMasterId { get; set; }
        public FamilyStatusMaster FamilyStatus { get; set; }

        [ForeignKey("FamilyType")]
        public int? FamilyTypeMasterId { get; set; }
        public FamilyTypeMaster FamilyType { get; set; }

        [ForeignKey("FamilyValues")]
        public int? FamilyValuesMasterId { get; set; }
        public FamilyValuesMaster FamilyValues { get; set; }

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
        public ICollection<ProfilePreferenceCaste> ProfilePreferenceCastes { get; set; }
        public ICollection<ProfilePreferenceEducations> ProfilePreferenceEducations { get; set; }
        public ICollection<ProfilePreferenceReligion> ProfilePreferenceReligions { get; set; }
        public ICollection<ProfilePreferenceSubCaste> ProfilePreferenceSubCastes { get; set; }
        public string PreferenceStar { get; set; }
        public string PreferenceRasi { get; set; }
        public string PreferenceChavvaiDosham { get; set; }
        public string PreferenceQualification { get; set; }

        #endregion
        public string UserId { get; set; }

    }
}
