using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class FamilyTypeMaster
    {
        [Key]
        public int FamilyTypeMasterId { get; set; }
        public string FamilyTypeName { get; set; }
    }
}
