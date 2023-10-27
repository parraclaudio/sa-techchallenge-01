using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using MongoDB.Driver;

namespace Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Insert(Cliente cliente)
    {
        var clienteDbEntity = new Entities.ClienteEntity()
        {
            Nome = cliente.Nome,
            CPF = cliente.CPF,
            Email = cliente.Email
        };
        
       _context.Clientes.InsertOne(clienteDbEntity);
    }

    public Cliente? GetByCPF(string cpf)
    {
        try
        {
            var findData = _context.Clientes.Find(c => c.CPF == cpf);

            if (findData.CountDocuments() == 0)
                return null;

            var dbClient = findData.FirstOrDefault();
            
            return new Cliente(dbClient.CPF, dbClient.Nome, dbClient.Email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}