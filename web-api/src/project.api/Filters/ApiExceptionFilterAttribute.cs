using Microsoft.AspNetCore.Mvc.Filters;
using jsm.product.manager.aspnetcore.infrastructure.FilterExceptions;
using jsm.product.manager.domain.Exceptions;

namespace jsm.product.manager.api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IApiFilterException _apiFilterException;
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;
        public ApiExceptionFilterAttribute(IApiFilterException apiFilterException, ILogger<ApiExceptionFilterAttribute> logger)
        {
            _apiFilterException = apiFilterException;
            _logger = logger;

        }
        public override void OnException(ExceptionContext context)
        {
            var result = (context.Exception) switch
            {
                InvalidOperationBusinessException ex => _apiFilterException.InvalidOperation(ex),
                EntityValidationException ex => _apiFilterException.EntityValidation(ex),
                NotFoundException ex => _apiFilterException.NotFoundException(ex),
                _ => _apiFilterException.InternalServerError(context.Exception)
            };

            context.ExceptionHandled = true;
            context.Result = result;

            base.OnException(context);
        }
    }
}
