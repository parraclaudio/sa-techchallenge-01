using Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Entities;

public class ProdutoEntity
{
    [BsonId]
    public Guid Id { get; set; }
    public string Nome { get;  set; }
    public string Descricao { get;  set; }
    public CategoriaProdutoEnum Categoria { get;  set; }
    public double Preco { get;  set; }
    public string Imagem { get;  set; }
}