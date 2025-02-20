using ApiMeteo.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiMeteo.DTO
{
    public class WatherDbContext: DbContext
    {
        public WatherDbContext() : base() { }
        public WatherDbContext(DbContextOptions<WatherDbContext > options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Preference> Preferences { get; set; }
    }
}
