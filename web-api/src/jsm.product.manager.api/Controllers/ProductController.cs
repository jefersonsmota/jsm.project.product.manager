using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using jsm.product.manager.application.Handlers.Products;
using jsm.product.manager.contracts.Products;

namespace jsm.product.manager.api.Controllers
{
    /// <summary>
    /// Api CRUD produtos
    /// </summary>
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICreateProduct _create;
        private readonly IUpdateProduct _update;
        private readonly IGetAllProducts _getAll;
        private readonly IGetProduct _get;
        private readonly IDeleteProduct _delete;
        public ProductController(
            ICreateProduct create,
            IUpdateProduct update,
            IGetAllProducts getAll,
            IGetProduct get,
            IDeleteProduct delete)
        {
            _create = create;
            _update = update;
            _getAll = getAll;
            _get = get;
            _delete = delete;
        }

        /// <summary>
        /// Obter todos os produtos da base
        /// </summary>
        /// <param name="skip">Ignora os n primeiros itens encontratos.</param>
        /// <param name="take">Recuperar a quantidade n dos resultados</param>
        /// <param name="cancellationToken">Propaga o cancelamento da requisição</param>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        [AllowAnonymous]
        [Produces(typeof(GetProductListResponse))]
        [Route("[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] int skip, [FromQuery] int take, CancellationToken cancellationToken)
        {
            return Ok(await _getAll.Handler(skip, take, cancellationToken));
        }

        /// <summary>
        /// Obter produto especifico por Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <param name="cancellationToken">Propaga o cancelamento da requisição</param>
        /// <returns>Produto</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("[controller]/{id:guid}")]
        [Produces(typeof(GetProductResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _get.Handler(id, cancellationToken));
        }

        /// <summary>
        /// Deleta um produto da base
        /// </summary>
        /// <param name="id">Requisição de exclusão com Id do produto</param>
        /// <param name="cancellationToken">Propaga o cancelamento da requisição</param>
        /// <returns>Confirmação de exclusão</returns>
        [HttpDelete]
        [AllowAnonymous]
        [Route("[controller]/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _delete.Handler(id, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Cria/Adiciona um novo produto na base
        /// </summary>
        /// <param name="req">Novo produto</param>
        /// <param name="cancellationToken">Propaga o cancelamento da requisição</param>
        /// <returns>Confirmação de inclusão</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("[controller]")]
        [Produces(typeof(PostProductResponse))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] PostProductRequest req, CancellationToken cancellationToken)
        {
            var response = await _create.Handler(req, cancellationToken);
            return Created($"/{response.Id}", response);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <param name="req">Produto atualizado</param>
        /// <param name="cancellationToken">Propaga o cancelamento da requisição</param>
        /// <returns>Confirmação de atualização</returns>
        [HttpPut]
        [AllowAnonymous]
        [Route("[controller]/{id:guid}")]
        [Produces(typeof(PutProductResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PutProductRequest req, CancellationToken cancellationToken)
        {
            return Ok(await _update.Handler(id, req, cancellationToken));
        }
    }
}
