using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class FamilyValuesMaster
    {
        [Key]
        public int FamilyValuesMasterId { get; set; }
        public string FamilyValuesName { get; set; }
    }
}
