using project.application.Commands.Request.Produto;
using project.application.Common.Models;
using System;
using System.Threading.Tasks;

namespace project.application.Common.Interfaces
{
    public interface IProdutoQueryHandler
    {
        Task<CommandResponse> GetAll(ProdutoFiltroRequest produtoFiltro);
        Task<CommandResponse> GetById(Guid id);
    }
}
