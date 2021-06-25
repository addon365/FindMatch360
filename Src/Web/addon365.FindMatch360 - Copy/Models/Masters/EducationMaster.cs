using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class EducationMaster
    {
        [Key]
        public int EducationMasterId { get; set; }
        public string EducationName { get; set; }

        [ForeignKey("EducationCategory")]
        public int EducationCategoryId { get; set; }
        public EducationCategoryMaster EducationCategory { get; set; }
        
        public ICollection<ProfilePreferenceEducations> PreferenceEducations { get; set; }

    }
}
