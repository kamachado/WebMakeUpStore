using ApiMakeUpStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMakeUpStore.Data
{
    public class BrandRepository : BaseRepository<Brand>, IRepository<Brand>
    {
        public BrandRepository(IDbContextFactory<DataContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
