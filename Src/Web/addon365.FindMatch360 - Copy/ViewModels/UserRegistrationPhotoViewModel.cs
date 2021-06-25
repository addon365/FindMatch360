using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class UserRegistrationPhotoViewModel
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; } 
    }
}
