using AutoMapper;
using project.application.Commands.Request.Produto;
using project.application.Common.Interfaces;
using project.application.Common.Models;
using project.domain.Constants;
using project.domain.Entities;
using project.domain.Notifications;
using project.repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace project.application.Handlers.Produtos
{
    /// <summary>
    /// Command Handler pra alterações de Produtos
    /// </summary>
    public class ProdutoCommandHandler : CommandHandler, IProdutoCommandHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCommandHandler(IProdutoRepository produtoRepository, IMapper mapper, NotificationContext notificationContext) : base(mapper, notificationContext)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<CommandResponse> Handler(AtualizarProdutoRequest produtoAtualizado)
        {
            var atualizado = _mapper.Map<Produto>(produtoAtualizado);

            if(!atualizado.IsValid())
            {
                _notificationContext.AddNotifications(atualizado.Validation);
                return BadRequest(null, Messages.INVALID_FIELDS);
            }

            return Ok(await _produtoRepository.Update(atualizado));
        }

        public async Task<CommandResponse> Handler(CriarProdutoRequest novoProduto)
        {
            var novo = _mapper.Map<Produto>(novoProduto);

            if (!novo.IsValid())
            {
                _notificationContext.AddNotifications(novo.Validation);
                return BadRequest(null, Messages.INVALID_FIELDS);
            }

            if(await _produtoRepository.CheckAlreadyExist(novo.Nome))
            {
                _notificationContext.AddNotification("Nome", Messages.PRODUCT_ALREADY_EXISTS);
                return BadRequest(null, Messages.PRODUCT_ALREADY_EXISTS);
            }

            return Created(await _produtoRepository.Add(novo), Messages.CREATED_SUCCESS);
        }

        public async Task<CommandResponse> Handler(DeleteProdutoRequest produtoDelete)
        {
            if(produtoDelete.Id == Guid.Empty)
            {
                _notificationContext.AddNotification("Id", Messages.INVALID_FIELDS);
                return BadRequest(null, Messages.INVALID_FIELDS);
            }

            var produto = await _produtoRepository.Get(produtoDelete.Id);

            if(produto == null)
            {
                _notificationContext.AddNotification("Id", Messages.NOT_FOUND);
                return NotFound(produtoDelete, Messages.NOT_FOUND);
            }

            return Ok(await _produtoRepository.Delete(produto));
        }
    }
}
