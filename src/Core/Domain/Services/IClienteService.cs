using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;

public interface IClienteService
{
    int RegisterCliente(Cliente cliente);
    
    Cliente SearchClienteByCPF(CPF cpf);
}