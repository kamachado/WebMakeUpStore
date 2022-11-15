using ApiMakeUpStore.Models;
using ApiMakeUpStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMakeUpStore.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
