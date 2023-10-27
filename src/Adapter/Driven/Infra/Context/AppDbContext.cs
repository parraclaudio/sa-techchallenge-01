using Infra.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Infra.Context;

public class AppDbContext 
{
    private readonly MongoClient mongoClient;
    private readonly IMongoDatabase database;

    public AppDbContext(IOptions<MongoDbConfig> config)
    {
        mongoClient = new MongoClient(config.Value.ConnectionString);
        database = mongoClient.GetDatabase(config.Value.Database);
        Map();
    }
    
    public IMongoCollection<Cliente> Clientes => database.GetCollection<Cliente>("Clientes");

    private void Map()
    {
        BsonClassMap.RegisterClassMap<Cliente>(cm => { cm.AutoMap(); });
    }
}
