using project.application.Common.Models;

namespace project.application.Common.Interfaces
{
    /// <summary>
    /// Interface para Command Response
    /// </summary>
    public interface IHttpCommandResponse
    {
        CommandResponse Created(object response, string message = null);

        CommandResponse Ok(object response, string message = null);

        CommandResponse BadRequest(object response, string message = null);

        CommandResponse NotFound(object response, string message = null);

        CommandResponse InternalError(object response, string message = null);
    }
}
