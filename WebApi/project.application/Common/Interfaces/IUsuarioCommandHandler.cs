using project.application.Commands.Request.Usuario;
using project.application.Common.Models;
using System.Threading.Tasks;

namespace project.application.Common.Interfaces
{
    public interface IUsuarioCommandHandler
    {
        Task<CommandResponse> Handler(LoginRequest login);
    }
}
