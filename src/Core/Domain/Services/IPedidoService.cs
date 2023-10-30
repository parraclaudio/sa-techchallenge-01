using Domain.Entities;

namespace Domain.Services;

public interface IPedidoService
{
    string GerarPedido(CarrinhoDeCompras carrinhoDeCompras);

    IList<FilaPedidos> BuscarTodosNaFila();

    IList<Pedido> BuscarTodos();
}