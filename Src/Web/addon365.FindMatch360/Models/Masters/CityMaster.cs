using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class CityMaster
    {
        [Key]
        public int CityMasterId { get; set; }
        public string CityName { get; set; }

        [ForeignKey("State")]
        public int StateMasterId { get; set; }
        public StateMaster State { get; set; }

    }
}
