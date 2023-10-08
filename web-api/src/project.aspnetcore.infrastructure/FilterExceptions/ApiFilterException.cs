using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using project.domain.Exceptions;

namespace project.aspnetcore.infrastructure.FilterExceptions
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
        public IActionResult InternalServerError(Exception exception)
        {
            var result = new
            {
                code = "SE0001",
                message = "An error occurred while processing your request.",
            };

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

            return new BadRequestObjectResult(result);
        }

        public IActionResult EntityValidation(EntityValidationException exception)
        {
            var result = new
            {
                code = "EV0001",
                message = JsonConvert.SerializeObject(exception.Data),
            };

            return new BadRequestObjectResult(result);
        }

        public IActionResult NotFoundException(NotFoundException exception)
        {
            var result = new
            {
                code = exception.Code,
                message = exception.Message,
            };

            return new NotFoundObjectResult(result);
        }
    }
}
