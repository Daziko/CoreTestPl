using Microsoft.EntityFrameworkCore;

namespace CoreTestPl.Entities
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
