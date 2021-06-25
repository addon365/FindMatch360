using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class EmployeedInMaster
    {
        [Key]
        public int EmployeedInMasterId { get; set; }
        public string EmployeedInName { get; set; }
    }
}
