using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using project.data.Configuration;
using project.domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace project.data.Context
{
    public interface IProjectDBContext : IDisposable
    {
        DbSet<Product> Products { get; }
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public partial class ProjectDBContext : DbContext, IProjectDBContext
    {
        private readonly IProductEntityFrameworkMapping _produtoEntityFrameworkMapping;


        public ProjectDBContext(DbContextOptions<ProjectDBContext> options, IProductEntityFrameworkMapping produtoEntityFrameworkMapping) : base(options)
        {
            _produtoEntityFrameworkMapping = produtoEntityFrameworkMapping;
        }

        public DbSet<Product> Products { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _produtoEntityFrameworkMapping.Map(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDBContext).Assembly);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return await this.Database.BeginTransactionAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["IsDeleted"] = true;
                item.CurrentValues["DeleteDateUtc"] = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
