﻿using Domain.Entities;

namespace Domain.Services;

public interface IClienteService
{
    void RegisterCliente(Cliente cliente);
    
    Cliente SearchClienteByCPF(string cpf);
}