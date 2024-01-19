using Comunikime.Context;
using Comunikime.Models;
using Comunikime.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Comunikime.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);

        public Produto GetProdutoById(int Produtoid)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == Produtoid);
        }
    }
}
