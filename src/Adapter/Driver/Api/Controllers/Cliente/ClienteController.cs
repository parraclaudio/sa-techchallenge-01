using Api.Controllers.Cliente.Request;
using Api.Controllers.Cliente.Response;
using AutoMapper;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Cliente;

/// <summary>
/// Serviços disponiveis no contexto do agregado cliente
/// </summary>
[ApiController]
[Route("cliente")]
[Produces("application/json")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;
    private readonly IMapper _mapper;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="clienteService"></param>
    public ClienteController(IClienteService clienteService, IMapper mapper)
    {
        _clienteService = clienteService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Cadastrar novo cliente
    /// </summary>
    /// <returns>Retorna o cliente cadastrado</returns>
    /// <response code="200">Retorna dados do cliente.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(ClienteResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    public IActionResult CadastrarCliente(ClienteRequest clienteRequest)
    {
        try
        {
            var cliente = new Domain.Entities.Cliente(clienteRequest.CPF, clienteRequest.Nome, clienteRequest.Email);
            
            _clienteService.CadastrarCliente(cliente);
            
            return Ok(new ClienteResponse(cliente.CPF, cliente.Nome, cliente.Email));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    /// <summary>
    /// Identificar cliente por CPF
    /// </summary>
    /// <returns>Retorna dados do cliente cadastrado</returns>
    /// <response code="200">Retorna dados do cliente.</response>
    /// /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpGet("pesquisarporcpf/{cpf}")]
    [ProducesResponseType(typeof(ClienteResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult BuscarClientePorCPF([FromRoute] string cpf = "58669754088")
    {
        try
        {
            var dbCliente = _clienteService.PesquisarClientePorCpf(cpf);

            return dbCliente is null 
                ? NoContent()
                : Ok(new ClienteResponse(dbCliente.CPF, dbCliente.Nome, dbCliente.Email));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
}