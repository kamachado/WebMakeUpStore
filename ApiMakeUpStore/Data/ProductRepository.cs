using ApiMakeUpStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMakeUpStore.Data
{
    public class ProductRepository : BaseRepository<Product>, IRepository<Product>
    {
        public ProductRepository(IDbContextFactory<DataContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
