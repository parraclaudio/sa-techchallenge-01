using Domain.Entities;

namespace Domain.Services;

public interface ICarrinhoDeComprasService
{
    void RegisterCliente(Cliente cliente);
    
    Cliente SearchClienteByCPF(string cpf);
}