using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain;

namespace OnionArchitecture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }    
    }
}
