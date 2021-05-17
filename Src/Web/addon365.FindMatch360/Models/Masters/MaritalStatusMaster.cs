using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class MaritalStatusMaster
    {

        [Key]
        public int MaritalStatusMasterId { get; set; }
        public string MaritalStatusName { get; set; }
    }
}
