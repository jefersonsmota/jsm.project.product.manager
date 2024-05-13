using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace jsm.product.manager.api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        [Route("[controller]")]
        public IActionResult Index()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version
                          ?? Assembly.GetEntryAssembly()?.GetName().Version;

            return Ok(new
            {
                Title = "Project 3pMYbIl",
                Description = "API RESTful CRUD Produto",
                Version = $"{version!.Major}.{version!.Minor}.{version!.Build}",
                Author = "Jefeson Mota"
            });
        }
    }
}
