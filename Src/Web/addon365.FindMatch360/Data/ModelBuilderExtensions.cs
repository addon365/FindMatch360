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
            modelBuilder.Entity<MaritalStatusMaster>().HasData(
                new MaritalStatusMaster { MaritalStatusMasterId=1,MaritalStatusName="Never Married"},
                new MaritalStatusMaster { MaritalStatusMasterId = 2, MaritalStatusName = "Widowed" },
                new MaritalStatusMaster { MaritalStatusMasterId = 3, MaritalStatusName = "Divorced" },
                new MaritalStatusMaster { MaritalStatusMasterId = 4, MaritalStatusName = "Awaiting divorce" }
                );
            modelBuilder.Entity<FamilyStatusMaster>().HasData(
                new FamilyStatusMaster { FamilyStatusMasterId=1,FamilStatusName="Middle class"},
                new FamilyStatusMaster { FamilyStatusMasterId = 2, FamilStatusName = "Upper middle class" },
                new FamilyStatusMaster { FamilyStatusMasterId = 3, FamilStatusName = "Rich" },
                new FamilyStatusMaster { FamilyStatusMasterId = 4, FamilStatusName = "Affluent" }
                );
            modelBuilder.Entity<FamilyTypeMaster>().HasData(
                new FamilyTypeMaster { FamilyTypeMasterId=1,FamilyTypeName="Join"},
                new FamilyTypeMaster { FamilyTypeMasterId = 2, FamilyTypeName = "Nuclear" }
                );
            modelBuilder.Entity<FamilyValuesMaster>().HasData(
                new FamilyValuesMaster { FamilyValuesMasterId=1,FamilyValuesName="Orthodox"},
                new FamilyValuesMaster { FamilyValuesMasterId = 2, FamilyValuesName = "Traditional" },
                new FamilyValuesMaster { FamilyValuesMasterId = 3, FamilyValuesName = "Moderate" },
                new FamilyValuesMaster { FamilyValuesMasterId = 4, FamilyValuesName = "Liberal" }
                );
            modelBuilder.Entity<EmployeedInMaster>().HasData(
                new EmployeedInMaster { EmployeedInMasterId=1,EmployeedInName="Goverment/PSU"},
                new EmployeedInMaster { EmployeedInMasterId = 2, EmployeedInName = "Private" },
                new EmployeedInMaster { EmployeedInMasterId = 3, EmployeedInName = "Business" },
                new EmployeedInMaster { EmployeedInMasterId = 4, EmployeedInName = "Defence" },
                new EmployeedInMaster { EmployeedInMasterId = 5, EmployeedInName = "Self Employed" },
                new EmployeedInMaster { EmployeedInMasterId = 6, EmployeedInName = "Not Working" }
                );
            modelBuilder.Entity<OccupationMaster>().HasData(
                new OccupationMaster { OccupationMasterId = 1, OccupationName = "Business Owner/Entrepreneur" },
                new OccupationMaster { OccupationMasterId = 2, OccupationName = "Executive" },
                new OccupationMaster { OccupationMasterId = 3, OccupationName = "Software Professional" },
                new OccupationMaster { OccupationMasterId = 4, OccupationName = "Manager" },
                new OccupationMaster { OccupationMasterId = 5, OccupationName = "Supervisor" },
                new OccupationMaster { OccupationMasterId = 6, OccupationName = "Engineer - Non IT" },
                new OccupationMaster { OccupationMasterId = 7, OccupationName = "Technician" },
                new OccupationMaster { OccupationMasterId = 8, OccupationName = "Clerk" },
                new OccupationMaster { OccupationMasterId = 9, OccupationName = "Marketing Professional" }
                );
            modelBuilder.Entity<CountryMaster>().HasData(
                new CountryMaster { CountryMasterId=1,CountryName="India"},
                new CountryMaster { CountryMasterId = 2, CountryName = "United States of America" },
                new CountryMaster { CountryMasterId = 3, CountryName = "United Arab Emirates" },
                new CountryMaster { CountryMasterId = 4, CountryName = "United kingdom" },
                new CountryMaster { CountryMasterId = 5, CountryName = "Australia" },
                new CountryMaster { CountryMasterId = 6, CountryName = "Singapore" },
                new CountryMaster { CountryMasterId = 7, CountryName = "Canada" },
                new CountryMaster { CountryMasterId = 8, CountryName = "Qatar" },
                new CountryMaster { CountryMasterId = 9, CountryName = "Kuwait" },
                new CountryMaster { CountryMasterId = 10, CountryName = "Oman" },
                new CountryMaster { CountryMasterId = 11, CountryName = "Bahrain" },
                new CountryMaster { CountryMasterId = 12, CountryName = "Saudi Arabia" },
                new CountryMaster { CountryMasterId = 13, CountryName = "Malasia" },
                new CountryMaster { CountryMasterId = 14, CountryName = "Germany" },
                new CountryMaster { CountryMasterId = 15, CountryName = "New Zealand" },
                new CountryMaster { CountryMasterId = 16, CountryName = "France" },
                new CountryMaster { CountryMasterId = 17, CountryName = "Ireland" },
                new CountryMaster { CountryMasterId = 18, CountryName = "Switzerland" },
                new CountryMaster { CountryMasterId = 19, CountryName = "South Africe" },
                new CountryMaster { CountryMasterId = 20, CountryName = "Sri Lanka" },
                new CountryMaster { CountryMasterId = 21, CountryName = "Indonesia" },
                new CountryMaster { CountryMasterId = 22, CountryName = "Nepal" },
                new CountryMaster { CountryMasterId = 23, CountryName = "Pakistan" },
                new CountryMaster { CountryMasterId = 24, CountryName = "Bangladesh" },
                new CountryMaster { CountryMasterId = 25, CountryName = "Afghanistan" }
                
                );
            modelBuilder.Entity<StateMaster>().HasData(
                new StateMaster { StateMasterId=1,StateName="Andaman & Nicobar", CountryMasterId=1},
                new StateMaster { StateMasterId = 2, StateName = "Andhra Pradesh", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 3, StateName = "Arunachal Pradesh", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 4, StateName = "Assam", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 5, StateName = "Bihar", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 6, StateName = "Chandigarh", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 7, StateName = "Chhattisgarh", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 8, StateName = "Dadra & Nagar Haveli", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 9, StateName = "Daman & Diu", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 10, StateName = "Delhi/NCR", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 11, StateName = "Goa", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 12, StateName = "Gujarat", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 13, StateName = "Haryana", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 14, StateName = "Himachal Pradesh", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 15, StateName = "Jammu & Kashmir", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 16, StateName = "Jharkand", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 17, StateName = "Karnataka", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 18, StateName = "Kerala", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 19, StateName = "Lakshwadeep", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 20, StateName = "Madhya Pradesh", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 21, StateName = "Maharashtra", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 22, StateName = "Manipur", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 23, StateName = "Meghalaya", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 24, StateName = "Mizoram", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 25, StateName = "Nagaland", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 26, StateName = "Orissa", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 27, StateName = "Pondicherry", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 28, StateName = "Punjab", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 29, StateName = "Rajasthan", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 30, StateName = "Sikkim", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 31, StateName = "Tamil Nadu", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 32, StateName = "Telangana", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 33, StateName = "Tripura", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 34, StateName = "Uttar Pradesh", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 35, StateName = "Uttarakhand", CountryMasterId = 1 },
                new StateMaster { StateMasterId = 36, StateName = "West Bengal", CountryMasterId = 1 }

                );
            modelBuilder.Entity<CityMaster>().HasData(
                new CityMaster { CityMasterId=1,CityName="Chennai",StateMasterId=31}
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
