using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class UserRegistrationReligionViewModel
    {
        public string CasteMasterId { get; set; }
        public IEnumerable<CasteMaster> Castes { get; set; }
        public string SubCasteMasterId { get; set; }
        public IEnumerable<SubCasteMaster> SubCastes { get; set; }
        public string GothramMasterId { get; set; }
        public IEnumerable<GothramMaster> Gothrams { get; set; }
    }
}
