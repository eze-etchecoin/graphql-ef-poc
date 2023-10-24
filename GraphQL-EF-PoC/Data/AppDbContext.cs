using Microsoft.EntityFrameworkCore;

namespace GraphQL_EF_PoC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Vehicle> Vehicles { get; set; }  
    }
}
