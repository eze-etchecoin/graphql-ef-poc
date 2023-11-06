using GraphQL_EF_PoC.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_EF_PoC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> Brands { get; set; }
        public DbSet<VehicleModel> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Model)
                .WithMany();

            modelBuilder.Entity<VehicleModel>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models);
        }
    }
}
