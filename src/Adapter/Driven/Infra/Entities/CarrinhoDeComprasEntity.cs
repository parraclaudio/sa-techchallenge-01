using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Entities;

public class CarrinhoDeComprasEntity
{
    [BsonId]
    public Guid Id { get; set; }
    public List<ProdutoEntity> Produtos { get;  set; }
}