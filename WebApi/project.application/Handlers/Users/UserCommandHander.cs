using project.contracts.Users;
using project.domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace project.application.Handlers.Usuarios
{
    /// <summary>
    /// Classe de para operações de alteração de um Usuário
    /// </summary>
    public class UserCommandHander
    {
        public readonly IUserRepository _usuarioRepository;

        public UserCommandHander(IUserRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task Handler(PostLoginRequest login)
        {
            var autenticacao = await _usuarioRepository.Login(login.UserName, login.Password);

        }
    }
}
