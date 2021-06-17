using project.domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<int> Add(Produto produto);
        Task<Produto> Get(Guid id);
        Task<IEnumerable<Produto>> GetAll();
        Task<int> Delete(Produto produto);
        Task<int> Update(Produto produto);
        Task<bool> CheckAlreadyExist(string nome);
    }
}
