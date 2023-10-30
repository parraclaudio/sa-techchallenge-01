using Domain.Entities;

namespace Domain.Repositories;

public interface IPedidoRepository
{
    void SalvarPedido(Pedido pedido);

    IList<Pedido> BuscarTodos();
}