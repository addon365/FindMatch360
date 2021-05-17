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
        public int CasteName { get; set; }
    }
}
