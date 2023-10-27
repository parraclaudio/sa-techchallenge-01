using Domain.ValueObjects;

namespace Domain.Entities;

public class Pedido
{
    public Pedido(string idCarrinhoDeCompras, ProgressoPedido progressoPedido, List<Produto> produtos)
    {
        IdPedido = Guid.NewGuid().ToString();
        IdCarrinhoDeCompras = idCarrinhoDeCompras;
        ProgressoPedido = progressoPedido;
        Produtos = produtos;
    }

    public string IdPedido { get; private set; }
    public string NumeroPedido => IdPedido.Substring(0,4);
    public string IdCarrinhoDeCompras { get; private set;}
    public ProgressoPedido ProgressoPedido { get; private set; }
    public List<Produto> Produtos { get; private set; }
}