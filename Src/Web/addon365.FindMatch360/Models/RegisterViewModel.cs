using addon365.FindMatch360.CustomValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace addon365.FindMatch360.Models
{
    public class RegisterViewModel
    {
        
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "VerifyEmail", controller: "Account")]
        [ValidEmailDomain(allowedDomain: "pragimtech.com",
        ErrorMessage = "Email domain must be pragimtech.com")]
        public string Email { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IamIndian { get; set; }
    }
}
