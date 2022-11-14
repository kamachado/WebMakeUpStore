using System.Linq.Expressions;

namespace ApiMakeUpStore.Data
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<IList<TModel>> GetList(Expression<Func<TModel, bool>>? condition = null);
        Task<TModel?> GetOne(Expression<Func<TModel, bool>> condition);
        Task<int> GetCount(Expression<Func<TModel, bool>>? condition = null);
        Task<TModel> Insert(TModel model);
        Task<TModel> Update(TModel model);
        Task<TModel?> UpdateAsync(Expression<Func<TModel, bool>> condition, Action<TModel> action);
        Task Remove(TModel model);
    }
}
