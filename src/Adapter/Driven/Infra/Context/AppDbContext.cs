using Domain.ValueObjects;
using Infra.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
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
    
    public IMongoCollection<ClienteEntity> Clientes => database.GetCollection<ClienteEntity>("Clientes");

    public IMongoCollection<ProdutoEntity> Produtos => database.GetCollection<ProdutoEntity>("Produtos");

    public IMongoCollection<CarrinhoDeComprasEntity> CarrinhoDeCompras => database.GetCollection<CarrinhoDeComprasEntity>("CarrinhoDeCompras");

    private void Map()
    {
        BsonClassMap.RegisterClassMap<ClienteEntity>(cm => { cm.AutoMap(); });
        BsonClassMap.RegisterClassMap<CarrinhoDeComprasEntity>(cm => { cm.AutoMap(); });
        BsonClassMap.RegisterClassMap<ProdutoEntity>(cm =>
        {
            cm.AutoMap();
            cm.MapMember(x => x.Categoria).SetSerializer(new EnumSerializer<CategoriaProdutoEnum>(BsonType.String));
        });
    }
}
