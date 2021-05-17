using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.MatrimonyProfileModels
{
    public class ProfileDoshams
    {
        [Key]
        public int ProfileDoshamsId { get; set; }
        
        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

        [ForeignKey("Dosham")]
        public int DoshamId { get; set; }
        public DoshamMaster Dosham { get; set; }


    }
}
