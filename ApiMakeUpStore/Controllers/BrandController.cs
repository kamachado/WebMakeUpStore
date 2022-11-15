using ApiMakeUpStore.Data.Extensions_Data;
using ApiMakeUpStore.Models;
using ApiMakeUpStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ApiMakeUpStore.Controllers
{
    public class BrandGetListQueryFilter
    {
        /// <summary>
        /// Brand's Name 
        /// </summary>
        [FromQuery(Name = "name")] public String? NameBrand { get; set; } = null;

        /// <summary>
        /// Brand's Country
        /// </summary>
        [FromQuery(Name = "country")] public string? BrandCountry { get; set; } = null;

        public void Deconstruct(out string? name, out string? country)
        {
            name = NameBrand;
            country = BrandCountry;
        }
    }

        
    [Route("brand")]
    [ApiController]
    public class BrandController : BaseController<Brand>
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService service) : base(service)
        {
            _brandService = service;
        }

        /// <summary>
        /// Search a list of Brands with or without filters
        /// </summary>
        /// <param name="queryFilter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResult<Brand>> GetList([FromQuery] BrandGetListQueryFilter queryFilter)
        {
            var (name,country) = queryFilter;

            Expression<Func<Brand, bool>>? condition = null;

            if (name != null) condition = condition.And(b=> b.Name == name);
            if (country != null) condition = condition.And(b => b.Country == country);

            var result = await _brandService.GetList(condition);

            var totalCount = await _brandService.GetCount(condition);

            return new ListResult<Brand>(totalCount,result);

        }

        /// <summary>
        /// Insert a new Brand
        /// </summary>
        /// <param name="dataBrand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post([FromBody] Brand dataBrand)
        {
           await _brandService.Insert(dataBrand);
        }

        /// <summary>
        /// Delete some brand by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var item = await _brandService.GetById(id);
            if (item != null) await _brandService.Remove(item);
        }

        /// <summary>
        /// Update the country of  some Brand
        /// </summary>
        /// <param name="nameBrand"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPut("country/{nameBrand}")]
        public async Task UpdateCountry([FromQuery] string nameBrand, [FromBody] string country )
        {
            await _brandService.UpdateAsync(b=>b.Name == nameBrand, b=> b.Country = country);
        }

        /// <summary>
        ///  Update the name of  some Brand
        /// </summary>
        /// <param name="idBrand"></param>
        /// <param name="nameBrand"></param>
        /// <returns></returns>
        [HttpPut("name/{nameBrand}")]
        public async Task UpdateName([FromBody] int idBrand, [FromQuery]  string nameBrand)
        {
            await _brandService.UpdateAsync(b => b.Id == idBrand, b => b.Name = nameBrand);
        }
    }
}
