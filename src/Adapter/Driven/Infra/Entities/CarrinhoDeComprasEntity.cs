using Domain.Entities;
using Domain.ValueObjects;

namespace Infra.Entities;

public class CarrinhoDeComprasEntity : BaseEntity
{
    public string IdCarrinhoDeCompras { get; set; }
    
    public string CPF { get;  set;}

    public StatusCarrinhoDeCompras Status { get;  set; }
    
    public OrdemPagamentoEntity OrdemDePagamento { get;  set;}
    
    public List<ProdutoEntity> Produtos { get;  set; }
    
}