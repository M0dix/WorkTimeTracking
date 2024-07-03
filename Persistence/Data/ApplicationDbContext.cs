using Microsoft.EntityFrameworkCore;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Configurations;

namespace WorkTimeTracking.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WorkReport> WorkReports { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
