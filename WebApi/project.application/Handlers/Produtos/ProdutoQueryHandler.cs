using AutoMapper;
using project.application.Commands.Request.Produto;
using project.application.Commands.Response.Produto;
using project.application.Common.Interfaces;
using project.application.Common.Models;
using project.domain.Constants;
using project.domain.Notifications;
using project.repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace project.application.Handlers.Produtos
{
    /// <summary>
    /// Classe Query Handler para operações de consulta de produtos
    /// </summary>
    public class ProdutoQueryHandler : CommandHandler, IProdutoQueryHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoQueryHandler(IProdutoRepository produtoRepository, IMapper mapper, NotificationContext notificationContext) : base(mapper, notificationContext)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<CommandResponse> GetAll(ProdutoFiltroRequest produtoFiltro)
        {
            return Ok(await _produtoRepository.GetAll(), null);
        }

        public async Task<CommandResponse> GetById(Guid id)
        {
            if(id == Guid.Empty)
            {
                _notificationContext.AddNotification("Id", Messages.INVALID_FIELDS);
                return BadRequest(id, Messages.INVALID_FIELDS);
            }

            var produto = await _produtoRepository.Get(id);

            if(produto == null)
            {
                _notificationContext.AddNotification("Id", Messages.NOT_FOUND);
                return BadRequest(id, Messages.NOT_FOUND);
            }

            return Ok(this._mapper.Map<ProdutoResponse>(produto));
        }
    }
}
