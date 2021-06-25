using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class EmployeedIndustryMaster
    {
        [Key]
        public int EmployeedIndustryMasterId { get; set; }
        public string EmployeedIndustryName { get; set; }
    }
}
