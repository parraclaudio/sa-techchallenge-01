using Domain.Entities;

namespace Domain.Services;

public interface ICarrinhoDeComprasService
{
    CarrinhoDeCompras? AdicionarProduto(string nomeProduto, string? cpf = null);
    
    void RemoverProduto( string idCarrinhoCompras, Produto produto);
    
    CarrinhoDeCompras? ExecutarCheckout(string idCarrinhoCompras);

    CarrinhoDeCompras BuscarCarrinhoDeComprasPorCpf(string cpf);


}