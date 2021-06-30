using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class ProfileIndexViewModel
    {
        public Guid ProfileMasterId { get; set; }
        public String RegistrationNo { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string PhotoUrl { get; set; }
        public string ProfileName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string Age { get
            {
                if(DateofBirth==null)
                {
                    return "";
                }
                // Save today's date.
                var today = DateTime.Today;

                // Calculate the age.
                var age = today.Year - DateofBirth.Value.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (DateofBirth.Value.Date > today.AddYears(-age)) age--;

                return age.ToString();
            }
        }
        public string Star { get; set; }
        public string EducationQualification { get; set; }
        public string JobDetail { get; set; }

        public string Address { get; set; }
    }
}
