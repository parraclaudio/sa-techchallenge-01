using Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Entities;

public class CarrinhoDeComprasEntity : BaseEntity
{

    public StatusCarrinhoDeCompras Status { get;  set; }
    
    public Guid IdCarrinhoDeCompras { get;  set;} 
    
    public string CPF { get;  set;} 
    public List<ProdutoEntity> Produtos { get;  set; }
}