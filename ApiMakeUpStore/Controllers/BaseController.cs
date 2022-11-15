using ApiMakeUpStore.Core;
using ApiMakeUpStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMakeUpStore.Controllers
{
    public record ListResult<T>(int TotalCount, IList<T> Result);

    public abstract class BaseController<TModel> : ControllerBase where TModel : class
    {
        private readonly IService<TModel> _service;

        protected BaseController(IService<TModel> service)
        {
            _service = service;
        }

        /// <summary>
        /// search by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        [HttpGet("{id}")]
        public virtual async Task<TModel> GetById(int id)
        {
            var item = await _service.GetById(id);
            if (item == null) throw new ApiException(StatusCodes.Status404NotFound, "Item não encontrado");
            return item;
        }

    }
}
