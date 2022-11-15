using ApiMakeUpStore.Core;
using ApiMakeUpStore.Data.Extensions_Data;
using ApiMakeUpStore.Models;
using ApiMakeUpStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ApiMakeUpStore.Controllers
{

    public class ProductGetListQueryFilter
    {
        /// <summary>
        /// Product's Type 
        /// </summary>
        [FromQuery(Name = "type")] public string? Type { get; set; } = null;

        /// <summary>
        /// Product's Name
        /// </summary>
        [FromQuery(Name = "name")] public string? Name { get; set; } = null;

        /// <summary>
        /// Product's Body part
        /// </summary>
        [FromQuery(Name = "bodyPart")] public string? BodyPart { get; set; } = null;

        /// <summary>
        /// Product's Brand
        /// </summary>
        [FromQuery(Name = "brand")] public int Brand { get; set; } = 0;

        /// <summary>
        /// Max price
        /// </summary>
        [FromQuery(Name = "maxPrice")] public double MaxPrice { get; set; } = 0;

        /// <summary>
        /// Min price
        /// </summary>
        [FromQuery(Name = "minPrice")] public double MinPrice { get; set; } = 0;

        public void Deconstruct(out string? type, out string? bodyPart, out int? brand, out double maxPrice, out double minPrice )
        {
            type = Type;
            bodyPart = BodyPart;
            brand = Brand;
            maxPrice = MaxPrice;
            minPrice = MinPrice;
        }
    }


    [Route("product")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService service) : base(service)
        {
            _productService = service;  
        }


        /// <summary>
        /// Search a list of Products with or without filters
        /// </summary>
        /// <param name="queryFilter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResult<Product>> GetList([FromQuery] ProductGetListQueryFilter queryFilter)
        {
            var (type,bodyPart,brand,
            maxPrice,minPrice ) = queryFilter;

            if(maxPrice != 0 && minPrice != 0 && maxPrice < minPrice ) throw new ApiException(500, "Erro ao buscar categorias");

            Expression<Func<Product, bool>>? condition = null;

            if (type != null) condition = condition.And(p => p.Type == type);
            if (bodyPart != null) condition = condition.And (p=> p.BodyPart == bodyPart);
            if (brand != 0) condition = condition.And(p => p.IdBrand == brand);
            if (maxPrice != 0) condition = condition.And(p => p.Price >= maxPrice);
            if (minPrice != 0) condition = condition.And(p => p.Price <= maxPrice);

            var result = await _productService.GetList(condition);

            var totalCount = await _productService.GetCount(condition);

            return new ListResult<Product>(totalCount, result);

        }

        /// <summary>
        /// Insert a new Product
        /// </summary>
        /// <param name="dataProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post([FromBody] Product dataProduct)
        {
            await _productService.Insert(dataProduct);
        }

        /// <summary>
        /// Update the quantity of  some Product
        /// </summary>
        /// <param name="nameProduct"></param>
        /// <param name="quantityProduct"></param>
        /// <returns></returns>
        [HttpPost("{nameProduct}")]
        public async Task UpdateQuantity([FromQuery] string nameProduct, [FromBody] int quantityProduct)
        {
            await _productService.UpdateAsync(p => p.Name == nameProduct, p => p.Quantity = quantityProduct);
        }

        /// <summary>
        /// Delete some product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var item = await _productService.GetById(id);
            if (item != null) await _productService.Remove(item);
        }
    }
}
