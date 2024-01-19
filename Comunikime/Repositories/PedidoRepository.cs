using Comunikime.Context;
using Comunikime.Migrations;
using Comunikime.Models;
using Comunikime.Repositories.Interfaces;

namespace Comunikime.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach (var carrinhoItens in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItens.Quantidade,
                    ProdutoId = carrinhoItens.Produto.ProdutoId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItens.Produto.Preco
                };
                _appDbContext.PedidosDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}

