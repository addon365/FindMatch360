using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class UserRegistrationProfessionalViewModel
    {
        public string EducationMasterId { get; set; }
        public IEnumerable<EducationMaster> Educations { get; set; }

        public string EducationDetail { get; set; }
        public string EmployeedInMasterId { get; set; }
        public IEnumerable<EmployeedInMaster> EmployeedInLst { get; set; }

        public string OccupationMasterId { get; set; }
        public IEnumerable<OccupationMaster> Occupations { get; set; }
    }
}
