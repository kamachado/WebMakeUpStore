using ApiMakeUpStore.Data;

namespace ApiMakeUpStore.Services
{
    public interface IService<TModel> : IRepository<TModel> where TModel : class
    {
        Task<TModel?> GetById(int id);
        Task RemoveById(int id);
    }
}
