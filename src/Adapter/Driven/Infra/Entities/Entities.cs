using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Entities;

public class Cliente
{
    [BsonId]
    public Guid Id { get; set; }
    public string CPF { get;  set; }
    public string Nome { get;  set; }
    public string Email{ get;  set; }
}