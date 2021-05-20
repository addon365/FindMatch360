using addon365.FindMatch360.CustomValidation;
using addon365.FindMatch360.Models.Masters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace addon365.FindMatch360.ViewModels
{
    public class PreRegisterViewModel
    {

        public string ProfileFor { get; set; }
        public IEnumerable<ProfileForMaster> ProfileForList { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string MobileNo { get; set; }

    }
}
