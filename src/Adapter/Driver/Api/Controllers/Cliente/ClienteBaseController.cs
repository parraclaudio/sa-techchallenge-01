using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Cliente;

[ApiController]
[Route("[controller]")]
public class ClienteBaseController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteBaseController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet("{cpf}")]
    public IActionResult Get(string cpf)
    {
        try
        {
            var dbCliente = _clienteService.SearchClienteByCpf(cpf);

            if (dbCliente is not null)
            {
                var clientResponse = new ClienteResponse(dbCliente);
                return Ok(clientResponse);
            }
                

            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Post(ClienteRequest clienteRequest)
    {
        try
        {
            var cliente = new Domain.Entities.Cliente(clienteRequest.CPF, clienteRequest.Nome, clienteRequest.Email);
            
            _clienteService.RegisterCliente(cliente);

            return Ok("Cliente cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}