﻿using Domain.Entities;
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
        var findCliente = SearchClienteByCpf(cliente.CPF);
        
        if (findCliente is not null)
        {
            throw new InvalidOperationException("Cliente ja registrado ! ");
        }
        
        _clienteRepository.Insert(cliente);
    }

    public Cliente? SearchClienteByCpf(string cpf)
    {
      return  _clienteRepository.GetByCPF(cpf);
    }
}