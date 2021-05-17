using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace addon365.FindMatch360.Data
{
    public class ilamaiMatrimonyContext:IdentityDbContext<ApplicationUser> 
    {
        public ilamaiMatrimonyContext(DbContextOptions<ilamaiMatrimonyContext> options):base(options)
        {

        }
        public DbSet<Profile> MatrimonyProfiles { get; set; }
        public DbSet<ProfileForMaster> profileForMasters { get; set; }
    }
}
