using System;
using System.ComponentModel.DataAnnotations;

namespace addon365.FindMatch360.Models
{
    public class MatrimonyProfile
    {
        [Key]
        public int MatrimonyProfileId { get; set; }
        public String Name { get; set; }
        public DateTime DateandTimeOfBirth { get; set; }
        public string Place { get; set; }
        public string Color { get; set; }
        public string Height { get; set; }
        public string Nakshatra { get; set; }
        public string Rasi { get; set; }
        public string Lagnam { get; set; }
        public Boolean ChevvaiDosham { get; set; }
        public short BirthNumberinFamily { get; set; }
        public short Brothers { get; set; }
        public short MarriedBrothers { get; set; }
        public short Sisters { get; set; }
        public short MarriedSisters { get; set; }

        #region JobDetails
        public string JobPosition { get; set; }
        public string CompanyAddress { get; set; }
        public string MonthlyRevenue { get; set; }
        #endregion

        #region FamilyDetails
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

        #endregion
        #region Expected
        public string ExpectedQualification { get; set; }

        #endregion

    }
}
