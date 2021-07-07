using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class MatrimonyProfilesDetailViewModel
    {
            public Guid ProfileId { get; set; }
            public String RegistrationNo { get; set; }
            public int? ProfileForId { get; set; }
            public DateTime RegisteredDate { get; set; }
            public DateTime CreatedDate { get; set; }

            #region Person basic Details
            public String Name { get; set; }
            public String LastName { get; set; }

        public string PhotoUrl { get; set; }
        public string PhotoName { get; set; }
            public byte Gender { get; set; }
            public DateTime? DateandTimeOfBirth { get; set; }
        public string Age
        {
            get
            {
                if (DateandTimeOfBirth == null)
                {
                    return "";
                }
                // Save today's date.
                var today = DateTime.Today;

                // Calculate the age.
                var age = today.Year - DateandTimeOfBirth.Value.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (DateandTimeOfBirth.Value.Date > today.AddYears(-age)) age--;

                return age.ToString();
            }
        }
        public int? MaritalStatusMasterId { get; set; }
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

            public string ProfileEducationName{ get; set; }
            public string ProfileEducationDetail { get; set; }
            #endregion

            #region JobDetails
            public string EmployeedInName { get; set; }
            public int? OccupationMasterId { get; set; }
            public int? WorkingCountryMasterId { get; set; }
            public int? WorkingStateMasterId { get; set; }
            public int? WorkingCityMasterId { get; set; }

            public string WorkingAddress { get; set; }
            public decimal? MonthlyRevenue { get; set; }
            #endregion

            #region ReligionDetails
            public int? ReligionMasterId { get; set; }
            public int? MotherTongueMasterId { get; set; }
            public int? CasteMasterId { get; set; }
            public int? SubCasteMasterId { get; set; }
            public int? GothramMasterId { get; set; }

            #endregion

            #region Horoscope Details
            public string Star { get; set; }
            public string Rasi { get; set; }
            public string Lagnam { get; set; }
            public string TimeofBirth { get; set; }
            public string PlaceOfBirth { get; set; }
            #endregion

            #region Family Information
            public int? FamilyStatusMasterId { get; set; }

            public int? FamilyTypeMasterId { get; set; }
            public int? FamilyValuesMasterId { get; set; }

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
      
            public string PreferenceStar { get; set; }
            public string PreferenceRasi { get; set; }
            public string PreferenceChavvaiDosham { get; set; }
            public string PreferenceQualification { get; set; }

            #endregion
         
            public string UserId { get; set; }
         
    }
    public static class MatrimonyProfilesDetailViewModelExtensions
    {
        public static MatrimonyProfilesDetailViewModel LoadProfile(this MatrimonyProfilesDetailViewModel model,Profile profile)
        {


            model.ProfileId = profile.ProfileMasterId;
            model.RegistrationNo = profile.RegistrationNo;
            model.Name = profile.Name;
            model.DateandTimeOfBirth = profile.DateandTimeOfBirth;
            model.EmployeedInName = profile.EmployeedIn != null ? profile.EmployeedIn.EmployeedInName :"";
            model.Address = profile.Address;
            model.SkinColor = profile.SkinColor;
            model.Star = profile.Star;
            model.Lagnam = profile.Lagnam;
            model.BirthNumberinFamily = profile.BirthNumberinFamily;
            model.Height = profile.Height;

            model.FatherName = profile.FatherName;
            model.FatherJob = profile.FatherJob;

            model.MotherName = profile.MotherName;
            model.MotherQualification = profile.MotherQualification;

            model.NativeDistrict = profile.NativeDistrict;
            model.MobileNo = profile.MobileNo;
            model.EmailId = profile.EmailId;

            model.PreferenceQualification = profile.PreferenceQualification;




            return model;
        }
    }
}
