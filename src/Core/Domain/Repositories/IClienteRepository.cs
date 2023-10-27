using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IClienteRepository
{
    IEnumerable<Cliente> GetAll();

    int Insert(Cliente cliente);
    
    Cliente GetByCPF(CPF cpf);
}