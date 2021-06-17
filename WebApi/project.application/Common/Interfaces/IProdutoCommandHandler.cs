using project.application.Commands.Request.Produto;
using project.application.Common.Models;
using System.Threading.Tasks;

namespace project.application.Common.Interfaces
{
    public interface IProdutoCommandHandler
    {
        Task<CommandResponse> Handler(AtualizarProdutoRequest produtoAtualizado);
        Task<CommandResponse> Handler(CriarProdutoRequest novoProduto);
        Task<CommandResponse> Handler(DeleteProdutoRequest produtoDelete);
    }
}
