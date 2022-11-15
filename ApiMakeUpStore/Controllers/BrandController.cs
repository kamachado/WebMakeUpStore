using ApiMakeUpStore.Models;
using ApiMakeUpStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMakeUpStore.Controllers
{
    [Route("brand")]
    [ApiController]
    public class BrandController : BaseController<Brand>
    {
        public BrandController(IBrandService service) : base(service)
        {
        }
    }
}
