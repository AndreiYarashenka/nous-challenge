using CleaningManagement.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CleaningManagement.DAL
{
    public class CleaningManagementDbContext : DbContext
    {
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase("CleaningContext");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CleaningPlanEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}