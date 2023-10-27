using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void RegisterCliente(Cliente cliente)
    {
        var findCliente = SearchClienteByCPF(cliente.CPF);
        
        if (findCliente.HasValue)
        {
            throw new InvalidOperationException("Cliente ja registrado ! ");
        }
        
        _clienteRepository.Insert(cliente);
    }

    public Cliente SearchClienteByCPF(string cpf)
    {
      return  _clienteRepository.GetByCPF(cpf);
    }
}