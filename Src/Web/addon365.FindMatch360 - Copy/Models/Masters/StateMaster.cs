using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class StateMaster
    {
        [Key]
        public int StateMasterId { get; set; }
        public string StateName { get; set; }

        [ForeignKey("Country")]
        public int CountryMasterId { get; set; }
        public CountryMaster Country { get; set; }

        public ICollection<CityMaster> Cities { get; set; }
    }
}
