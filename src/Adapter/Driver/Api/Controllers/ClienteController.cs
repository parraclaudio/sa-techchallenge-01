using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IClienteService _clienteService;

    public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
    {
        _logger = logger;
        _clienteService = clienteService;
    }

    [HttpGet("{cpf}")]
    public Cliente Get( CPF cpf)
    {
        return _clienteService.SearchClienteByCPF(cpf);
    }
}