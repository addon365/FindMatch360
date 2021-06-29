using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class MatrimonyProfilesIndexViewModel
    {
       public IEnumerable<ProfileIndexViewModel> Profiles { get; set; }
       public IEnumerable<ProfileIndexViewModel> SimilarProfiles { get; set; }
    }
}
