using ApiMakeUpStore.Data;
using ApiMakeUpStore.Models;

namespace ApiMakeUpStore.Services
{
    public interface IBrandService : IService<Brand>
    {

    }
    public class BrandService : BaseService<Brand>, IBrandService
    {
        public BrandService(IRepository<Brand> repository) : base(repository)
        {
        }

        public override Task<Brand?> GetById(int id)
        {
            return _repository.GetOne(b => b.Id == id);
        }
    }
}
