using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class ReligionMaster
    {
        [Key]
        public int ReligionMasterId { get; set; }
        public string ReligionName { get; set; }
        public ICollection<Profile> Profiles { get; set; }
        public ICollection<ProfilePreferenceReligion> PreferenceReligions { get; set; }

    }
}
