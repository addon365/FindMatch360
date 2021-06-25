using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.MatrimonyProfileModels
{
    public class ProfilePreferenceReligion
    {
        [Key]
        public int ProfilePreferenceReligionId { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

        [ForeignKey("Religion")]
        public int ReligionMasterId { get; set; }
        public ReligionMaster Religion { get; set; }
    }
}
