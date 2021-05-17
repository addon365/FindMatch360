using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.MatrimonyProfileModels
{
    public class ProfilePreferenceSubCaste
    {
        [Key]
        public int ProfilePreferenceSubCasteId { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

        [ForeignKey("SubCaste")]
        public int SubCasteMasterId { get; set; }
        public SubCasteMaster SubCaste { get; set; }
    }
}
