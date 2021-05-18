using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class SubCasteMaster
    {
        [Key]
        public int SubCasteMasterId { get; set; }
        public string SubCasteName { get; set; }
        [ForeignKey("ParentCaste")]
        public int CasteMasterId { get; set; }
        public CasteMaster ParentCaste { get; set; }
        public ICollection<CasteMaster> Castes { get; set; }
        public ICollection<ProfilePreferenceSubCaste> PreferenceSubCastes { get; set; }
        public ICollection<Profile> Profiles { get; set; }

    }
}
