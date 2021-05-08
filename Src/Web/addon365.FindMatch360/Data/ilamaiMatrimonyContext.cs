using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Data
{
    public class ilamaiMatrimonyContext:IdentityDbContext 
    {
        public ilamaiMatrimonyContext(DbContextOptions<ilamaiMatrimonyContext> options):base(options)
        {

        }
        public DbSet<addon365.FindMatch360.Models.MatrimonyProfile> MatrimonyProfiles { get; set; }
    }
}
