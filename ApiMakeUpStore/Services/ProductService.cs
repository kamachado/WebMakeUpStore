using ApiMakeUpStore.Data;
using ApiMakeUpStore.Models;

namespace ApiMakeUpStore.Services
{
    public interface IProductService : IService<Product>
    {

    }
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository) : base(repository)
        {
        }

        public override Task<Product?> GetById(int id)
        {
            return _repository.GetOne(p=> p.Id == id);
        }
    }
}
