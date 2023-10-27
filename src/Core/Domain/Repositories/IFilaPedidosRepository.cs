using Domain.Entities;

namespace Domain.Repositories;

public interface IFilaPedidosRepository
{
   void SalvarPedidoNaFila(FilaPedidos pedidos);
   
   IList<FilaPedidos> PesquisarFilaDePedigos();
}