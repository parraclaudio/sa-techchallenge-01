using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Controllers.CarrinhoDeCompras.Response;

public class CarrinhoDeComprasResponse
{
    public string IdCarrinhoDeCompras { get;  set; }
    
    public bool ClienteIdentificado => (CPF is not null);
    
    public string? CPF { get;  set;}

    public StatusCarrinhoDeCompras Status { get;  set; }
    
    public OrdemDePagamento OrdemDePagamento { get;  set;}
    
    public List<Domain.Entities.Produto> Produtos { get;  set; }

    public string NumeroPedido { get;  set; }
    
    public double SomaDoPreco { get;  set; }
    
    public int QuantidadeItens { get;  set; }
}