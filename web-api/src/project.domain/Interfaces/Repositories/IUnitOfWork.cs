using System;
using System.Threading;
using System.Threading.Tasks;

namespace project.domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction(CancellationToken cancellationToken);
        Task Commit(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
