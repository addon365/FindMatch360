using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace addon365.FindMatch360.Models.Masters
{
    public class ProfileForMaster
    {
        [Key]
        public int ProfileForId { get; set; }
        public string ProfileFor { get; set; }
        public byte Gender { get; set; }
    }
}
