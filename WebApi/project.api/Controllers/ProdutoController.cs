using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.application.Commands.Request.Produto;
using project.application.Common.Interfaces;
using project.domain.Notifications;
using System;
using System.Threading.Tasks;

namespace project.api.Controllers
{
    /// <summary>
    /// Api CRUD produtos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ApiController
    {
        public ProdutoController(NotificationContext notificationContext) : base(notificationContext) { }

        /// <summary>
        /// Obter todos os produtos da base
        /// </summary>
        /// <param name="produtoQueryHandler">Command handler para efetuar comandos de consulta.</param>
        /// <param name="produtoFiltro">Opcional para filtrar e paginar produtos</param>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromServices] IProdutoQueryHandler produtoQueryHandler, [FromQuery] ProdutoFiltroRequest produtoFiltro)
        {
            return Response(await produtoQueryHandler.GetAll(produtoFiltro));
        }

        /// <summary>
        /// Obter produto especifico por Id
        /// </summary>
        /// <param name="produtoQueryHandler">Command handler para efetuar comandos de consulta.</param>
        /// <param name="id">Id do produto</param>
        /// <returns>Produto</returns>
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromServices] IProdutoQueryHandler produtoQueryHandler, [FromQuery] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Response(await produtoQueryHandler.GetById(id));
        }

        /// <summary>
        /// Deleta um produto da base
        /// </summary>
        /// <param name="produtoCommandHandler">Command handler para efetuar comandos de alterações</param>
        /// <param name="req">Requisição de exclusão com Id do produto</param>
        /// <returns>Confirmação de exclusão</returns>
        [HttpDelete]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromServices] IProdutoCommandHandler produtoCommandHandler, [FromQuery] DeleteProdutoRequest req)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Response(await produtoCommandHandler.Handler(req));
        }

        /// <summary>
        /// Cria/Adiciona um novo produto na base
        /// </summary>
        /// <param name="produtoCommandHandler">Command handler para efetuar comandos de alterações</param>
        /// <param name="req">Novo produto</param>
        /// <returns>Confirmação de inclusão</returns>
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromServices] IProdutoCommandHandler produtoCommandHandler, [FromBody] CriarProdutoRequest req)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Response(await produtoCommandHandler.Handler(req));
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="produtoCommandHandler">Command handler para efetuar comandos de alterações</param>
        /// <param name="req">Produto atualizado</param>
        /// <returns>Confirmação de atualização</returns>
        [HttpPut]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromServices] IProdutoCommandHandler produtoCommandHandler, [FromBody] AtualizarProdutoRequest req)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Response(await produtoCommandHandler.Handler(req));
        }
    }
}
