using Comunikime.Models;

namespace Comunikime.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; } 
        Produto GetProdutoById(int Produtoid);
    }
}
