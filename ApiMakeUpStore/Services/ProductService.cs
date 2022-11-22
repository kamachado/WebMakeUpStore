using ApiMakeUpStore.Data;
using ApiMakeUpStore.Models;

namespace ApiMakeUpStore.Services
{
    public interface IProductService : IService<Product>
    {
        Task InsertProduct(Product model);
    }
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IConfiguration _configuration;
        public ProductService(IRepository<Product> repository, IConfiguration configuration) : base(repository)
        {
            _configuration = configuration;
        }

        public override Task<Product?> GetById(int id)
        {
            return _repository.GetOne(p=> p.Id == id);
        }

        public async Task InsertProduct(Product model)
        {

           var  modelNew = new Product {
               Name = model.Name,
               Type = model.Type,
               BodyPart = model.BodyPart,
               Price = model.Price,
               Description = model.Description,
               IdBrand = model.IdBrand,
               Quantity = model.Quantity
           };

            await _repository.Insert(modelNew);
        }

       

    }
}
