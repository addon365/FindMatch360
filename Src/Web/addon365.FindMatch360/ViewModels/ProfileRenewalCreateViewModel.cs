using addon365.FindMatch360.Models.MatrimonyProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class ProfileRenewalCreateViewModel
    {
        public int ProfileRenewalSpecialId { get; set; }
        public int CreatedDate { get; set; }
        public DateTime RenewalDate { get; set; }
        public Guid ProfileId { get; set; }
        public IEnumerable<Profile> Profiles { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
