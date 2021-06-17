using Microsoft.EntityFrameworkCore;
using project.domain.Entities;
using project.repository.Context;
using project.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.repository.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly ProjectDBContext _context;

        public ProdutoRepository(ProjectDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckAlreadyExist(string nome)
        {
            return await _context.Produtos.AnyAsync(x => x.Nome.ToLower() == nome.ToLower());
        }

        public async Task<int> Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            return await _context.SaveChangesAsync();
        }

        public async Task<Produto> Get(Guid id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<int> Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            return await _context.SaveChangesAsync();
        }
    }
}
