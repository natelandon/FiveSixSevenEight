using FiveSixSevenEight.Models;
using Microsoft.EntityFrameworkCore;
using FiveSixSevenEight.Data;

namespace FiveSixSevenEight.Data
{
    public class DanceContext : DbContext
    {
        public DanceContext(DbContextOptions<DanceContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DanceEventCategory> DanceEventCategories { get; set; }
        public DbSet<DanceEvent> DanceEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<DanceEventCategory>().ToTable("DanceEventCategory");
            modelBuilder.Entity<DanceEvent>().ToTable("DanceEvent");

            modelBuilder.Entity<DanceEventCategory>()
                .HasKey(c => new { c.DanceEventID, c.CategoryID });
        }
    }
}
