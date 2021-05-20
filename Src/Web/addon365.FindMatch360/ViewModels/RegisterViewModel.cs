using addon365.FindMatch360.CustomValidation;
using addon365.FindMatch360.Models.Masters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace addon365.FindMatch360.ViewModels
{
    public class RegisterViewModel
    {

        public string ProfileFor { get; set; }
        public IEnumerable<ProfileForMaster> ProfileForList { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string ReligionMasterId { get; set; }
        public string MotherTongueMasterId { get; set; }
        //[Remote(action: "VerifyEmail", controller: "Account")]
        //[ValidEmailDomain(allowedDomain: "pragimtech.com",
        //ErrorMessage = "Email domain must be pragimtech.com")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password",
        //    ErrorMessage = "Password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
        //public bool IamIndian { get; set; }
    }
}
