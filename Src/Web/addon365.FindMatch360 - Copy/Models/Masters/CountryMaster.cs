using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class CountryMaster
    {
        [Key]
        public int CountryMasterId { get; set; }
        public string CountryName { get; set; }
        public ICollection<StateMaster> States { get; set; }
    }
}
