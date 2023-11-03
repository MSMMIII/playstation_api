using Microsoft.EntityFrameworkCore;
using PlaystationAPI.Models;

namespace PlaystationAPI.Data
{
    public class PlaystationContext : DbContext
    {
        public PlaystationContext(DbContextOptions<PlaystationContext> options) : base(options) { }

        public DbSet<Playstation> Playstations { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Playstation>().ToTable("Playstation");
        }
    }
}
