using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.application.Commands.Request.Usuario;
using project.application.Common.Interfaces;
using project.domain.Notifications;
using System.Threading.Tasks;

namespace project.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ApiController
    {
        public AutenticacaoController(NotificationContext notificationContext) : base(notificationContext)
        {
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromServices] IUsuarioCommandHandler usuarioCommandHandler, [FromBody] LoginRequest login)
        {
            if(ModelState.IsValid)
            {
                return Response(await usuarioCommandHandler.Handler(login));
            }

            return BadRequest();
        }
    }
}
