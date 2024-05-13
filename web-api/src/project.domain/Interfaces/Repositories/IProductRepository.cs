using jsm.product.manager.domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace jsm.product.manager.domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task Add(Product produto, CancellationToken cancellationToken);
        Task<bool> CheckAlreadyExist(string nome, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAll(int skip, int take, CancellationToken cancellationToken);
        Task<Product> Get(Guid id, CancellationToken cancellationToken);
        Task<Product> GetOrDefault(Guid id, CancellationToken cancellationToken);
        void Delete(Product produto, CancellationToken cancellationToken);
        void Update(Product produto, CancellationToken cancellationToken);
    }
}
