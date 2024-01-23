using Microsoft.EntityFrameworkCore;

namespace ServisTakipWebAPI.Models
{
    public class ServisTakipDbContext : DbContext
    {
        public ServisTakipDbContext(DbContextOptions<ServisTakipDbContext> options) : base(options)
        {
        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<FaultTrack>? FaultTracks { get; set; }
    }
}