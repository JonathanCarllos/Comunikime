using Comunikime.Models;
using Comunikime.Repositories.Interfaces;
using Comunikime.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Comunikime.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Produto> produto;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(categoria))
            {
                produto = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todos os produtos";
            }
            else
            {
                produto = _produtoRepository.Produtos
                    .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }

            var produtoListViewModel = new ProdutoListViewModel
            {
                Produtos = produto,
                CategoriaAtual = categoriaAtual
            };

            return View(produtoListViewModel);            
        }

        public IActionResult Details(int produtoId)
        {
            var produto = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            return View(produto);       
        
        }
    }
}
