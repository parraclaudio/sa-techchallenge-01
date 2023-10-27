using Domain.Entities;

namespace Domain.Repositories;

public interface IPedidoRepository
{
    void SalvarPedido(Pedido pedido);
}