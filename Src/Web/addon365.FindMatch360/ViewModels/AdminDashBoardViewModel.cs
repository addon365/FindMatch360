using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class AdminDashBoardViewModel
    {
        public int TotalMembers { get; set; }
        public int PaidMembers { get; set; }
        public int InactiveMembers { get; set; }
        public int Visitors { get; set; }
        public IEnumerable<RecentMember> RecentMembers { get; set; }
    }
    public class RecentMember
    {
        public int SNo { get; set; }
        public int RegNo { get; set; }
        public DateTime RegDate { get; set; }
        public string Name { get; set; }
        public string Caste { get; set; }
        public string Job { get; set; }
        public string Qualification { get; set; }
        public string Place { get; set; }
        public decimal Salary { get; set; }
    }
}
