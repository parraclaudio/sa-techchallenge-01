using Domain.Entities;

namespace Domain.Repositories;

public interface ICarrinhoDeComprasRepository
{
    CarrinhoDeCompras? Atualizar(CarrinhoDeCompras carrinhoDeCompras);
    
    CarrinhoDeCompras? BuscarCarrinhoDeComprasPorCpf(string cpf);
    
    CarrinhoDeCompras? BuscarCarrinhoDeComprasPorId(string id);

    CarrinhoDeCompras? BuscarCarrinhoDeComprasPorIdCarrinhoDeCompras(string? idCarrinhoDeCompras);
}