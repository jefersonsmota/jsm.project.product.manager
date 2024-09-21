using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using jsm.product.manager.domain.Exceptions;

namespace jsm.product.manager.aspnetcore.infrastructure.FilterExceptions
{
    public interface IApiFilterException
    {
        IActionResult InternalServerError(Exception exception);
        IActionResult InvalidOperation(InvalidOperationBusinessException exception);
        IActionResult EntityValidation(EntityValidationException exception);
        IActionResult NotFoundException(NotFoundException exception);
    }
    public class ApiFilterException : IApiFilterException
    {
        private readonly ILogger<ApiFilterException> _logger;
        public ApiFilterException(ILogger<ApiFilterException> logger)
        {
            _logger = logger;
        }
        public IActionResult InternalServerError(Exception exception)
        {
            var result = new
            {
                code = "SE0001",
                message = "An error occurred while processing your request.",
            };

            _logger.LogError(exception, "Internal Server Erro {code} : {message}", result.code, result.message);

            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }

        public IActionResult InvalidOperation(InvalidOperationBusinessException exception)
        {
            var result = new
            {
                code = exception.Code,
                message = exception.Message,
            };

            _logger.LogWarning(exception, "Invalid operation {code} : {message}", result.code, result.message);

            return new BadRequestObjectResult(result);
        }

        public IActionResult EntityValidation(EntityValidationException exception)
        {
            var result = new
            {
                code = "EV0001",
                message = JsonConvert.SerializeObject(exception.Data),
            };

            _logger.LogWarning(exception, "Error validation {code} : {message}", result.code, result.message);

            return new BadRequestObjectResult(result);
        }

        public IActionResult NotFoundException(NotFoundException exception)
        {
            var result = new
            {
                code = exception.Code,
                message = exception.Message,
            };

            _logger.LogWarning(exception, "Not found {code} : {message}", result.code, result.message);

            return new NotFoundObjectResult(result);
        }
    }
}
