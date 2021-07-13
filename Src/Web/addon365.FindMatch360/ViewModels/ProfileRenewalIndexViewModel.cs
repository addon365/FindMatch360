using addon365.FindMatch360.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class ProfileRenewalIndexViewModel
    {
        public PaginatedList<ProfileRenewalListViewModel> AllRenewals { get; set; }

    }
    public class ProfileRenewalListViewModel
    {
        public Guid ProfileRenewalMasterId { get; set; }
        public int ProfileRenewalSpecialId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime RenewalDate { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
