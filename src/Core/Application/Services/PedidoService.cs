using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IFilaPedidosRepository _filaPedidosRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IFilaPedidosRepository filaPedidosRepository)
    {
        _pedidoRepository = pedidoRepository;
        _filaPedidosRepository = filaPedidosRepository;
    }

    public string GerarPedido(CarrinhoDeCompras carrinhoDeCompras)
    {
        var pedido = new Pedido(carrinhoDeCompras.IdCarrinhoDeCompras, ProgressoPedido.Recebido,
            carrinhoDeCompras.Produtos);
        
        _pedidoRepository.SalvarPedido(pedido);
        
        var filaPedidos = new FilaPedidos(pedido.NumeroPedido, 1);
        
        _filaPedidosRepository.SalvarPedidoNaFila(filaPedidos);
        
        return pedido.NumeroPedido;
    }

    public IList<FilaPedidos> BuscarTodosNaFila()
    {
        return _filaPedidosRepository.PesquisarFilaDePedigos();
    }
}