using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Entities;

namespace Infra.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    
    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void SalvarPedido(Pedido pedido)
    {
        var produtos = pedido.Produtos.Select(p => new ProdutoEntity()
        {
            Nome = p.Nome,
            Categoria = p.Categoria,
            Descricao = p.Descricao,
            Imagem = p.Imagem,
            Preco = p.Preco
        }).ToList();


        var pedidoEntity = new PedidoEntity()
        {
            IdCarrinhoDeCompras = pedido.IdCarrinhoDeCompras,
            IdPedido = pedido.IdPedido,
            ProgressoPedido = pedido.ProgressoPedido,
            Produtos = produtos
        };

        _context.Pedido.InsertOne(pedidoEntity);
    }
}