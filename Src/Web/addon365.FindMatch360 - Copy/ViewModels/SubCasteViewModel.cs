using addon365.FindMatch360.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.ViewModels
{
    public class SubCasteViewModel
    {
        public string SubCasteName { get; set; }
        public string ParentCasteId { get; set; }
        public IEnumerable<CasteMaster> Castes { get; set; }
    }
}
