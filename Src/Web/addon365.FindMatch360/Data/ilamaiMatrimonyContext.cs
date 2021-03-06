using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace addon365.FindMatch360.Data
{
    public class ilamaiMatrimonyContext : IdentityDbContext<ApplicationUser>
    {
        public ilamaiMatrimonyContext(DbContextOptions<ilamaiMatrimonyContext> options) : base(options)
        {

        }
        public DbSet<ProfileRenewal> ProfileRenewals { get; set; }

#region Profile Tables
        public DbSet<Profile> Profiles { get; set; }
     
        public DbSet<ProfilePreferenceCaste> ProfilePreferenceCastes { get; set; }
        public DbSet<ProfilePreferenceEducations> ProfilePreferenceEducations { get; set; }
        public DbSet<ProfilePreferenceReligion> ProfilePreferenceReligions { get; set; }
        public DbSet<ProfilePreferenceSubCaste> ProfilePreferenceSubCastes { get; set; }
#endregion
#region Masters
        public DbSet<CasteMaster> CasteMasters { get; set; }
        public DbSet<DoshamMaster> DoshamMasters { get; set; }
        public DbSet<EducationCategoryMaster> EducationCategoryMasters { get; set; }
        public DbSet<EducationMaster> EducationMasters { get; set; }
        public DbSet<EmployeedIndustryMaster> EmployeedIndustryMasters { get; set; }
        public DbSet<EmployeedInMaster> EmployeedInMasters { get; set; }
        public DbSet<FamilyStatusMaster> FamilyStatusMasters { get; set; }
        public DbSet<FamilyTypeMaster> FamilyTypeMasters { get; set; }
        public DbSet<FamilyValuesMaster> FamilyValuesMasters { get; set; }
        public DbSet<GothramMaster> GothramMasters { get; set; }
        public DbSet<MaritalStatusMaster> MaritalStatusMasters { get; set; }
        public DbSet<MotherTongueMaster> MotherTongueMasters { get; set; }
        public DbSet<OccupationMaster> OccupationMasters { get; set; }
        public DbSet<ProfileForMaster> ProfileForMasters { get; set; }
        public DbSet<ReligionMaster> ReligionMasters{ get; set; }
        public DbSet<SubCasteMaster> SubCasteMasters { get; set; }
        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<RasiMaster> RasiMasters { get; set; }
        public DbSet<LagnamMaster> LagnamMasters { get; set; }
        public DbSet<StarMaster> StarMasters { get; set; }

#endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            //modelBuilder.Entity<Profile>()
            //    .HasOne(b => b.SubCaste)
            //    .WithMany(a => a.Profiles)
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
   
}
