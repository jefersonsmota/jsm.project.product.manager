using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.api.Controllers
{
    [Route("")]
    [ApiController]
    [AllowAnonymous]
    public class AboutController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok(new
            {
                Title = "Project 3pMYbIl",
                Description = "API RESTful CRUD Produto",
                Version = "1.0.0",
                Author = "Jefeson Mota"
            });
        }
    }
}
