using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;

public interface IClienteService
{
    void RegisterCliente(Cliente cliente);
    
    Cliente SearchClienteByCPF(string cpf);
}