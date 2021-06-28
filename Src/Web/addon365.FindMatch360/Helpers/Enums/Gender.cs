using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace addon365.FindMatch360.Helpers.Enums
{
    public enum Gender
    {
        [Display(Name = "Not Selected")]
        NotSelected =0, 
        Male=1, 
        Female=2}
}
