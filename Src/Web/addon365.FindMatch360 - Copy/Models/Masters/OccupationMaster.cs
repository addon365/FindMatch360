using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class OccupationMaster
    {
        [Key]
        public int OccupationMasterId { get; set; }
        public string OccupationName { get; set; }
    }
}
