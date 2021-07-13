using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class RasiMaster
    {
        [Key]
        public int RasiMasterId { get; set; }
        public string RasiName { get; set; }
        public ICollection<Profile> Profiles { get; set; }
    }
}
