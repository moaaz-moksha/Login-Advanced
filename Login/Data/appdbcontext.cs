using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data
{
    public class appdbcontext : DbContext
    {
        public appdbcontext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Login>().HasIndex(x => x.email).IsUnique();
        }

        public DbSet<Models.Login> logins { get; set; }
    }
}
