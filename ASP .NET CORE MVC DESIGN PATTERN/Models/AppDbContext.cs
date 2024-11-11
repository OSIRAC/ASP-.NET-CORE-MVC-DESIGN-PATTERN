using Microsoft.EntityFrameworkCore;

namespace EFCORE_VERİALMA.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
