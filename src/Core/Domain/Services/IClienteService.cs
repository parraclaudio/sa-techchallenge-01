using Domain.Entities;

namespace Domain.Services;

public interface IClienteService
{
    void CadastrarCliente(Cliente cliente);
    
    Cliente? PesquisarClientePorCpf(string cpf);
}