using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class GothramMaster
    {
        [Key]
        public int GothramMasterId { get; set; }
        public string GothramName { get; set; }
    }
}
