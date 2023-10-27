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
        Entities.ClienteEntity clienteDbEntity = new Entities.ClienteEntity()
        {
            Nome = cliente.Nome,
            CPF = cliente.CPF.ToString(),
            Email = cliente.Email
        };
        
       _context.Clientes.InsertOne(clienteDbEntity);
    }

    public Cliente GetByCPF(string cpf)
    {
        try
        {
            var clienteDbEntity = _context.Clientes.Find(c => c.CPF == cpf).FirstOrDefault();

            if (clienteDbEntity is null)
                return new Cliente();
            
            return new Cliente(clienteDbEntity.CPF, clienteDbEntity.Nome, clienteDbEntity.Email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
      
    }
}