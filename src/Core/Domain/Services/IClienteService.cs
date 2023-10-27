using Domain.Entities;

namespace Domain.Services;

public interface IClienteService
{
    void RegisterCliente(Cliente cliente);
    
    Cliente? SearchClienteByCpf(string cpf);
}