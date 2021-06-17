using AutoMapper;
using project.application.Commands.Request.Usuario;
using project.application.Common.Interfaces;
using project.application.Common.Models;
using project.domain.Notifications;
using project.repository.Interfaces;
using project.domain.Entities;
using System.Threading.Tasks;
using project.domain.Constants;

namespace project.application.Handlers.Usuarios
{
    /// <summary>
    /// Classe de para operações de alteração de um Usuário
    /// </summary>
    public class UsuarioCommandHander : CommandHandler, IUsuarioCommandHandler
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHander(IUsuarioRepository usuarioRepository, IMapper mapper, NotificationContext notificationContext) : base(mapper, notificationContext)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task<CommandResponse> Handler(LoginRequest login)
        {
            var usuarioLogin = _mapper.Map<Usuario>(login);

            if(!usuarioLogin.IsValid())
            {
                _notificationContext.AddNotifications(usuarioLogin.Validation);
                return BadRequest(null, Messages.INVALID_FIELDS);
            }

            var autenticacao = await _usuarioRepository.login(usuarioLogin);

            if(!autenticacao.success)
            {
                _notificationContext.AddNotification("login",autenticacao.error);
                return BadRequest(login, autenticacao.error);
            }

            return Ok(autenticacao);
        }
    }
}
