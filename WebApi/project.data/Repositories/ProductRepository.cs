using Microsoft.EntityFrameworkCore;
using project.data.Context;
using project.domain.Entities;
using project.domain.Exceptions.Products;
using project.domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace project.data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly IProjectDBContext _context;

        public ProductRepository(IProjectDBContext context)
        {
            _context = context;
        }

        public async Task Add(Product produto, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(produto, cancellationToken);
        }

        public async Task<bool> CheckAlreadyExist(string nome, CancellationToken cancellationToken)
        {
            return await _context.Products.AnyAsync(x => x.Name.ToLower() == nome.ToLower());
        }

        public void Delete(Product produto, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                _context.Products.Remove(produto);
            }
        }

        public async Task<Product> GetOrDefault(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Product> Get(Guid id, CancellationToken cancellationToken)
        {
            return await GetOrDefault(id, cancellationToken) ?? throw new ProductNotFoundException("P0001", id);
        }

        public async Task<IEnumerable<Product>> GetAll(int skip, int take, CancellationToken cancellationToken)
        {
            return await _context.Products
                                 .Skip(skip)
                                 .Take(take)
                                 .AsNoTracking()
                                 .ToListAsync(cancellationToken);
        }

        public void Update(Product produto, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                _context.Products.Update(produto);
            }
        }
    }
}
