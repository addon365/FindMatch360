using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class EducationCategoryMaster
    {
        [Key]
        public int EducationCategoryMasterId { get; set; }
        public string EducationCategoryName { get; set; }
        public ICollection<EducationMaster> EducationMasters { get; set; }

    }
}
