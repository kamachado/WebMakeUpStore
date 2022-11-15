using ApiMakeUpStore.Data;
using ApiMakeUpStore.Models;

namespace ApiMakeUpStore.Services
{
    public interface IProductService : IService<Product>
    {
         string GetFileFormat(string fullFileName);
        Task InsertProduct(Product model, IFormFile file);
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

        public  string GetFileFormat(string fullFileName)
        {
            var format = fullFileName.Split(".").Last();
            return "." + format;

        }
        private static string GenerateNewFileName(string fileName)
        {
            var newFileName = (fileName).ToLower();
            newFileName = newFileName.Replace("-", "");
            return newFileName;
        }
        private byte[] ConvertFileInByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }


        public async Task InsertProduct(Product model, IFormFile file)
        {
            string fileName = GenerateNewFileName(file.FileName);

            byte[] bytesFile = ConvertFileInByteArray(file);

            string directory = CreateFilePath(fileName);

            await File.WriteAllBytesAsync(directory, bytesFile);

           var  modelNew = new Product {
               Name = model.Name,
               Type = model.Type,
               BodyPart = model.BodyPart,
               Photo = directory,
               Price = model.Price,
               Description = model.Description,
               IdBrand = model.IdBrand,
               Quantity = model.Quantity
           };

            await _repository.Insert(modelNew);
        }

        private string CreateFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), _configuration["Directories:Files"], fileName);
        }


    }
}
