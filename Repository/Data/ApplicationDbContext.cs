using BookProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace BookProduct.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {


        }
        public DbSet<Product> Products { get; set; }
    }
}
