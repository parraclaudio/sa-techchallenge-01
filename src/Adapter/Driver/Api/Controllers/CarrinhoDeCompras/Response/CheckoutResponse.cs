namespace Api.Controllers.CarrinhoDeCompras.Response;

public class CheckoutResponse
{
    public string NumeroPedido { get;  set; }
    
    public double SomaDoPreco { get;  set; }
    
    public int QuantidadeItens { get;  set; }
    
    public List<Domain.Entities.Produto> Produtos { get;  set; }
}