using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoshamMaster>().HasData(
                new DoshamMaster{DoshamMasterId=1,DoshamName="Test"},
                new DoshamMaster { DoshamMasterId = 2, DoshamName = "Test2" }

            );
        }
    }
}
