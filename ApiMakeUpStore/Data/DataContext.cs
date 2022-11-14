using Microsoft.EntityFrameworkCore;

namespace ApiMakeUpStore.Data
{
    public class DataContext : DbContext
    {
       // public DbSet<Model> Equipament { get; set; }
     
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
