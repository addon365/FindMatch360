using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class LagnamMaster
    {
        [Key]
        public int LagnamMasterId { get; set; }
        public string LagnamName { get; set; }
        public ICollection<Profile> Profiles { get; set; }
    }
}
