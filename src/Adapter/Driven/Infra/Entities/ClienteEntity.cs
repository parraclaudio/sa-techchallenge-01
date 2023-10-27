using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Entities;

public class ClienteEntity
{
    [BsonId]
    public Guid Id { get; set; }
    public string CPF { get;  set; }
    public string Nome { get;  set; }
    public string Email{ get;  set; }
}