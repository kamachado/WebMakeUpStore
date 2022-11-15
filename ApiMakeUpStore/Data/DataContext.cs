using ApiMakeUpStore.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace ApiMakeUpStore.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand{ get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
