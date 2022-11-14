using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiMakeUpStore.Data
{
    public class BaseRepository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly IDbContextFactory<DataContext> _dbContextFactory;

        public BaseRepository(IDbContextFactory<DataContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<TModel?> GetOne(Expression<Func<TModel, bool>> condition)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>().AsNoTracking();
            IQueryable<TModel> query = dbset.Where(condition);
            return await query.FirstOrDefaultAsync();

        }

        public async Task<IList<TModel>> GetList(Expression<Func<TModel, bool>>? condition = null)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>().AsNoTracking();
            IQueryable<TModel> query = condition != null ? dbset.Where(condition) : dbset;
            return await query.ToListAsync();

        }
        public virtual async Task<TModel?> UpdateAsync(Expression<Func<TModel, bool>> condition, Action<TModel> action)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<TModel>();
            var item = await dbSet.FirstOrDefaultAsync(condition);
            if (item == null) return null;
            action.Invoke(item);
            //dbSet.Update(item);
            await dbContext.SaveChangesAsync();
            return item;
        }


        public async Task<TModel> Insert(TModel model)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>();
            await dbset.AddAsync(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task Remove(TModel model)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>();
            dbset.Remove(model);
            await dbContext.SaveChangesAsync();

        }

        public async Task<TModel> Update(TModel model)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>();
            dbset.Update(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<int> GetCount(Expression<Func<TModel, bool>>? condition = null)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>().AsNoTracking();
            IQueryable<TModel> query = condition != null ? dbset.Where(condition) : dbset;
            return await query.CountAsync();
        }
    }
}
