using Domain.Entities;

namespace Domain.Repositories;

public interface IClienteRepository
{
     void Insert(Cliente cliente);
    
    Cliente GetByCPF(string cpf);
}