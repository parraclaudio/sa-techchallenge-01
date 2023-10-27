using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Entities;
using MongoDB.Driver;

namespace Infra.Repositories;

public class FilaPedidosRepository : IFilaPedidosRepository
{
    private readonly AppDbContext _context;
    
    public FilaPedidosRepository(AppDbContext context)
    {
        _context = context;
    }

    
    public void SalvarPedidoNaFila(FilaPedidos pedidos)
    {
        var filaPedidosEntity = new FilaPedidosEntity()
        {
            NumeroPedido = pedidos.NumeroPedido,
            Prioridade = pedidos.Prioridade,
            ExpectativaFinalizacao = pedidos.ExpectativaFinalizacao
        };
        
        _context.FilaPedidos.InsertOne(filaPedidosEntity);
    }

    public IList<FilaPedidos> PesquisarFilaDePedigos()
    {
        var db = _context.FilaPedidos.Find(_ => true).ToList();

        return db.Select(f => new FilaPedidos(f.NumeroPedido, f.Prioridade, f.ExpectativaFinalizacao)).ToList();
    }
}