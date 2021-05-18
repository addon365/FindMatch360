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
            modelBuilder.Entity<ProfileForMaster>().HasData(
               new ProfileForMaster { ProfileForId = 1, ProfileFor = "Myself" },
               new ProfileForMaster { ProfileForId = 2, ProfileFor = "Daughter" },
               new ProfileForMaster { ProfileForId = 3, ProfileFor = "Son" },
               new ProfileForMaster { ProfileForId = 4, ProfileFor = "Sister" },
               new ProfileForMaster { ProfileForId = 5, ProfileFor = "Brother" },
               new ProfileForMaster { ProfileForId = 6, ProfileFor = "Relative" },
               new ProfileForMaster { ProfileForId = 7, ProfileFor = "Friend" }
              

           );
            modelBuilder.Entity<DoshamMaster>().HasData(
                new DoshamMaster{DoshamMasterId=1,DoshamName="Test"},
                new DoshamMaster { DoshamMasterId = 2, DoshamName = "Test2" }

            );

            modelBuilder.Entity<ReligionMaster>().HasData(
                new ReligionMaster { ReligionMasterId=1,ReligionName="Not Selected"},
                new ReligionMaster { ReligionMasterId = 2, ReligionName = "Hindu" },
                new ReligionMaster { ReligionMasterId = 3, ReligionName = "Muslim - Shia" },
                new ReligionMaster { ReligionMasterId = 4, ReligionName = "Muslim - Sunni" },
                new ReligionMaster { ReligionMasterId = 5, ReligionName = "Muslim - Others" },
                new ReligionMaster { ReligionMasterId = 6, ReligionName = "Christian" },
                new ReligionMaster { ReligionMasterId = 7, ReligionName = "Sikh" },
                new ReligionMaster { ReligionMasterId = 8, ReligionName = "Jain - Digambar" },
                new ReligionMaster { ReligionMasterId = 9, ReligionName = "Jain - Shwetambar" },
                new ReligionMaster { ReligionMasterId = 10, ReligionName = "Jain - Others" },
                new ReligionMaster { ReligionMasterId = 11, ReligionName = "Parsi" },
                new ReligionMaster { ReligionMasterId = 12, ReligionName = "Buddhist" },
                new ReligionMaster { ReligionMasterId = 13, ReligionName = "Inter-Religion" }

                );

            modelBuilder.Entity<MotherTongueMaster>().HasData(
                new MotherTongueMaster { MotherTongueMasterId = 1,MotherTongueName="Not Selected"},
                new MotherTongueMaster { MotherTongueMasterId = 2, MotherTongueName = "Tamil" },
                new MotherTongueMaster { MotherTongueMasterId = 3, MotherTongueName = "Telugu" },
                new MotherTongueMaster { MotherTongueMasterId = 4, MotherTongueName = "Hindi" },
                new MotherTongueMaster { MotherTongueMasterId = 5, MotherTongueName = "Kannada" },
                new MotherTongueMaster { MotherTongueMasterId = 6, MotherTongueName = "Malayalam" },
                new MotherTongueMaster { MotherTongueMasterId = 7, MotherTongueName = "Marathi" },
                new MotherTongueMaster { MotherTongueMasterId = 8, MotherTongueName = "Bengali" },
                new MotherTongueMaster { MotherTongueMasterId = 9, MotherTongueName = "Gujarati" },
                new MotherTongueMaster { MotherTongueMasterId = 10, MotherTongueName = "Punjabi" },
                new MotherTongueMaster { MotherTongueMasterId = 11, MotherTongueName = "Sindhi" },
                new MotherTongueMaster { MotherTongueMasterId = 12, MotherTongueName = "Urdu" },
                new MotherTongueMaster { MotherTongueMasterId = 13, MotherTongueName = "Oriya" }
                );
        }
    }
}
