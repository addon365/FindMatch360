using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Models.MatrimonyProfileModels
{
    public class ProfilePhotos
    {
        [Key]
        public int ProfilePhotosId { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        
        public byte[] Photo { get; set; }    }
}
