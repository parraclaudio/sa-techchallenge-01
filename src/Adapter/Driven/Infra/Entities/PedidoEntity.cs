using Domain.ValueObjects;

namespace Infra.Entities;

public class PedidoEntity :  BaseEntity
{
    public string IdPedido { get;  set; }
    public string IdCarrinhoDeCompras { get;  set;}
    public ProgressoPedido ProgressoPedido { get;  set; }
    public List<ProdutoEntity> Produtos { get;  set; }
}