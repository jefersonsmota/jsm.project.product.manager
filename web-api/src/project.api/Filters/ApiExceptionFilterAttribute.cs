using Microsoft.AspNetCore.Mvc.Filters;
using project.aspnetcore.infrastructure.FilterExceptions;
using project.domain.Exceptions;

namespace project.api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IApiFilterException _apiFilterException;
        public ApiExceptionFilterAttribute(IApiFilterException apiFilterException)
        {
            _apiFilterException = apiFilterException;
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
