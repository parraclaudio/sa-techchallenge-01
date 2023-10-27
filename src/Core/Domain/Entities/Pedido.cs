using Domain.ValueObjects;

namespace Domain.Entities;

public class Pedido
{
    public long NumeroPedido { get; private set; }
    public string IdCarrinhoDeCompras { get; private set;}
    public ProgressoPedido ProgressoPedido { get; private set; }
    public List<Produto> Produtos { get; private set; }
}