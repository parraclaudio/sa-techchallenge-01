using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Entities;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
}