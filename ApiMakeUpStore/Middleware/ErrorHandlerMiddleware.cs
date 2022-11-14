using ApiMakeUpStore.Core;
using System.Text.Json;

namespace ApiMakeUpStore.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.StatusCode = ex switch
                {
                    ApiException apiException => apiException.ErrorCode,
                    _ => StatusCodes.Status500InternalServerError,
                };
                var errorReponse = new ApiErrorResponse(ex.Message);
                var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
                await response.WriteAsJsonAsync(errorReponse, jsonOptions);
            }
        }
    }
}
