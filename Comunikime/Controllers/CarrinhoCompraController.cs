using Comunikime.Models;
using Comunikime.Repositories.Interfaces;
using Comunikime.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Comunikime.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, CarrinhoCompra carrinhoCompra)
        {
            _produtoRepository = produtoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCompraItems();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItem(int produtoId)
        {
            var produtoselecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            
            if(produtoselecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoselecionado);
            }

            return RedirectToAction("Index"); 
        }

        [Authorize]
        public IActionResult RemoverItem(int produtoId)
        {
            var produtoselecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produtoselecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(produtoselecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
