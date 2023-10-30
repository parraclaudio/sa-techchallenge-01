using Domain.ValueObjects;

namespace Api.Controllers.Pedido.Response;

public class PedidoResponse
{
    public string IdPedido { get;  set; }
    public string NumeroPedido { get; set; }
    public string IdCarrinhoDeCompras { get;  set;}
    public ProgressoPedido ProgressoPedido { get;  set; }
    public List<Domain.Entities.Produto> Produtos { get;  set; }
}