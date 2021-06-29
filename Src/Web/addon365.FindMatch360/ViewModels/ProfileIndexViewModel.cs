using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class ProfileIndexViewModel
    {
        public Guid ProfileMasterId { get; set; }
        public string PhotoUrl { get; set; }
        public string ProfileName { get; set; }
        public int Age { get; set; }
        public string Star { get; set; }
        public string EducationQualification { get; set; }
        public string JobDetail { get; set; }

        public string Address { get; set; }
    }
}
