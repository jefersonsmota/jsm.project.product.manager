using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace project.api.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("[controller]")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
