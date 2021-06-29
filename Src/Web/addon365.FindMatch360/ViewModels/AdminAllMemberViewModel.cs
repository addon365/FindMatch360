using addon365.FindMatch360.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class AdminAllMemberViewModel
    {
         //public IEnumerable<TotalMember> TotalMembers { get; set; }
        public PaginatedList<TotalMember> TotalMembers { get; set; }
    }
    public class TotalMember
    {
        public Guid ProfileMasterId { get; set; }
        public int SNo { get; set; }
        public Guid MatrimonyProfileId { get; set; }
        public int RegNo { get; set; }
        public DateTime RegDate { get; set; }
        public string ProfileName { get; set; }
        public string Caste { get; set; }
        public string Job { get; set; }
        public string Qualification { get; set; }
        public string Place { get; set; }
        public decimal MonthlyRevenue { get; set; }
    }
}
