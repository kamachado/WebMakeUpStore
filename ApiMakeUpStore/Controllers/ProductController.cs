using ApiMakeUpStore.Core;
using ApiMakeUpStore.Data.Dtos.Product;
using ApiMakeUpStore.Data.Extensions_Data;
using ApiMakeUpStore.Models;
using ApiMakeUpStore.Services;
using ApiMakeUpStore.Validator;
using AutoMapper;
using FluentValidation;
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

        public void Deconstruct(out string? type,out string? name, out string? bodyPart, out int? brand, out double? maxPrice, out double? minPrice )
        {
            type = Type;
            name = Name;
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
        private IMapper _mapper;
        private readonly IValidator<Product> _validator;
        public ProductController(IProductService service, IMapper mapper, IValidator<Product> validator) : base(service)
        {
            _productService = service;  
            _mapper = mapper;
            _validator = validator;
        }


        /// <summary>
        /// Search a list of Products with or without filters
        /// </summary>
        /// <param name="queryFilter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResult<ReadProductDto>> GetList([FromQuery] ProductGetListQueryFilter queryFilter)
        {
            var (type,name,bodyPart, brand,
            maxPrice,minPrice ) = queryFilter;

            if(maxPrice != 0 && minPrice != 0 && maxPrice < minPrice ) throw new ApiException(500, "Erro ao buscar categorias");

            Expression<Func<Product, bool>>? condition = null;

            if (type != null) condition = condition.And(p => p.Type == type);
            if (bodyPart != null) condition = condition.And (p => p.BodyPart == bodyPart);
            if (name != null) condition = condition.And(p => p.Name == name);
            if (brand != 0) condition = condition.And(p => p.IdBrand == brand);
            if (maxPrice != 0) condition = condition.And(p => p.Price <= maxPrice);
            if (minPrice != 0) condition = condition.And(p => p.Price >= minPrice);

            var result = await _productService.GetList(condition);
            var products = _mapper.Map<IList<ReadProductDto>>(result);
            var totalCount = await _productService.GetCount(condition);

            return new ListResult<ReadProductDto>(totalCount, products);

        }

        /// <summary>
        ///  Insert a new Product
        /// </summary>
        /// <param name="dataProduct"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        [HttpPost]
        public async Task Post([FromBody]CreateProductDto dataProduct)
        {
            var newProduct = _mapper.Map<Product>(dataProduct);
            var productValidate = _validator.Validate(newProduct);
            if (productValidate.IsValid)
            {
                await _productService.InsertProduct(newProduct);
            }
        }

        /// <summary>
        /// Update the quantity of  some Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantityProduct"></param>
        /// <returns></returns>
        [HttpPost("update/{id}")]
        public async Task UpdateQuantity(int id, [FromBody] int quantityProduct)
        {
            await _productService.UpdateAsync(p => p.Id == id, p => p.Quantity = quantityProduct);
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
