using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class CasteMaster
    {
        [Key]
        public int CasteMasterId { get; set; }
        public string CasteName { get; set; }
        public ICollection<SubCasteMaster> SubCasteMasters{get;set;}
        public ICollection<Profile> Profiles { get; set; }
    }
}
