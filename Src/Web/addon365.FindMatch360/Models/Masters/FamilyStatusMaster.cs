﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.Masters
{
    public class FamilyStatusMaster
    {
        [Key]
        public int FamilyStatusMasterId { get; set; }
        public string FamilStatusName { get; set; }
    }
}
