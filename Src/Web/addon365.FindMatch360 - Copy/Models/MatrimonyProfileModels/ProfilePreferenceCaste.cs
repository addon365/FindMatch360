using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.MatrimonyProfileModels
{
    public class ProfilePreferenceCaste
    {
        [Key]
        public int ProfilePreferenceCasteId { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

        [ForeignKey("Caste")]
        public int CasteMasterId { get; set; }
        public CasteMaster Caste { get; set; }
    }
}
