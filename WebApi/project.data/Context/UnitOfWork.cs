using Microsoft.EntityFrameworkCore.Storage;
using project.domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace project.data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IProjectDBContext _db;
        private IDbContextTransaction _transaction;
        public UnitOfWork(IProjectDBContext db)
        {
            _db = db;
        }

        public async Task BeginTransaction(CancellationToken cancellationToken)
        {
            if (_transaction == null)
            {
                _transaction = await _db.BeginTransactionAsync(cancellationToken);
            }
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            if (_transaction == null)
            {
                await _transaction.CommitAsync(cancellationToken);
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _db.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}
