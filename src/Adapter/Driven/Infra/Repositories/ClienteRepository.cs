using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    public IEnumerable<Cliente> GetAll()
    {
        throw new NotImplementedException();
    }

    public int Insert(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Cliente GetByCPF(CPF cpf)
    {
        throw new NotImplementedException();
    }
}