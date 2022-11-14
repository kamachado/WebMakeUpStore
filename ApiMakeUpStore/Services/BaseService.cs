using ApiMakeUpStore.Data;
using System.Linq.Expressions;

namespace ApiMakeUpStore.Services
{
    public abstract class BaseService<TModel> : IService<TModel> where TModel : class
    {
        protected readonly IRepository<TModel> _repository;

        protected BaseService(IRepository<TModel> repository)
        {
            _repository = repository;
        }

        public abstract Task<TModel?> GetById(int id);

        public Task<IList<TModel>> GetList(Expression<Func<TModel, bool>>? condition = null)
        {
            return _repository.GetList(condition);
        }

        public Task<TModel?> GetOne(Expression<Func<TModel, bool>> condition)
        {
            return _repository.GetOne(condition: condition);
        }


        public virtual Task<TModel> Insert(TModel model)
        {
            return _repository.Insert(model);
        }


        public virtual Task<TModel> Update(TModel model)
        {
            return _repository.Update(model);
        }


        public virtual Task Remove(TModel model)
        {
            return _repository.Remove(model);
        }

        public virtual async Task RemoveById(int id)
        {
            var item = await GetById(id);
            if (item == null) return;
            await _repository.Remove(item);
        }

        public virtual async Task<TModel?> UpdateAsync(Expression<Func<TModel, bool>> condition, Action<TModel> action)
        {
            return await _repository.UpdateAsync(condition, action);
        }

        public Task<int> GetCount(Expression<Func<TModel, bool>>? condition = null)
        {
            return _repository.GetCount(condition);
        }
    }
}
