using Microsoft.EntityFrameworkCore;

namespace ParksAPI.Models
{
    public class ParksAPIContext : DbContext
    {
        public ParksAPIContext(DbContextOptions<ParksAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Park>()
          .HasData(
            new Park { ParkId = 1, Name = "Yosemite", State = "California", Type = "National" },
            new Park { ParkId = 2, Name = "Big Basin Redwoods", State = "California", Type = "National" },
            new Park { ParkId = 3, Name = "Yellowstone", State = "Montana", Type = "National" },
            new Park { ParkId = 4, Name = "Bridal Veil Falls", State = "Oregon", Type = "State" },
            new Park { ParkId = 5, Name = "Crater Lake National Park", State = "Oregon", Type = "National" },
            new Park { ParkId = 6, Name = "Lime Kiln Point", State = "Washington", Type = "State" },
            new Park { ParkId = 7, Name = "Eagle Island Marine", State = "Washington", Type = "State" },
            new Park { ParkId = 8, Name = "Otter Point", State = "Oregon", Type = "State" }
          );
        }
    
        public DbSet<Park> Parks { get; set; }
    }
}