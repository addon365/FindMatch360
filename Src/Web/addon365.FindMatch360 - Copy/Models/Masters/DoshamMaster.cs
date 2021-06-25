using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class DoshamMaster
    {
        [Key]
        public int DoshamMasterId { get; set; }
        public string DoshamName { get; set; }
    }
}
