using System;
using System.Threading;
using System.Threading.Tasks;

namespace jsm.product.manager.domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction(CancellationToken cancellationToken);
        Task Commit(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
