using Comunikime.Context;
using Comunikime.Models;
using Comunikime.Repositories.Interfaces;

namespace Comunikime.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}