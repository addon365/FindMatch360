using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class UserRegistrationPersonalViewModel
    {
        public string? MaritalStatusMasterId { get; set; }
        public IEnumerable<MaritalStatusMaster> MaritalStatusMasters { get; set; }
        public string FamilyStatusMasterId { get; set; }
        public IEnumerable<FamilyStatusMaster> FamilyStatuses { get; set; }
        public string FamilyTypeMasterId { get; set; }
        public IEnumerable<FamilyTypeMaster> FamilyTypes { get; set; }
        public string FamilyValuesMasterId { get; set; }
        public IEnumerable<FamilyValuesMaster> FamilyValues { get; set; }
    }
}
