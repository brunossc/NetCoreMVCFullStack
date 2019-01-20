using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public  class AppDbInMemoryContext : DbContext
    {
        public AppDbInMemoryContext(DbContextOptions options) 
            : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}