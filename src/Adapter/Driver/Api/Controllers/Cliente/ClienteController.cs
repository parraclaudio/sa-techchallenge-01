using Api.Controllers.Cliente.Request;
using Api.Controllers.Cliente.Response;
using AutoMapper;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Cliente;

/// <summary>
/// 
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
    /// Adicionar produto
    /// </summary>
    /// <returns>Retorna o carrinho de compras</returns>
    /// <response code="200">Retorna o estado atual do carrinho de compras.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(ClienteResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    public IActionResult CadastrarCliente(ClienteRequest clienteRequest)
    {
        try
        {
            var cliente = new Domain.Entities.Cliente(clienteRequest.CPF, clienteRequest.Nome, clienteRequest.Email);
            
            _clienteService.RegisterCliente(cliente);
            
            return Ok(_mapper.Map<ClienteResponse>(cliente));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    /// <summary>
    /// Pesquisar carrinho de compras por CPF
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o pedido criado</returns>
    /// <response code="200">Retorna o pedido criado.</response>
    /// /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpGet("{cpf}")]
    [ProducesResponseType(typeof(ClienteResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult BuscarClientePorCPF(string cpf)
    {
        try
        {
            var dbCliente = _clienteService.SearchClienteByCpf(cpf);

            return dbCliente is null 
                ? NoContent()
                : Ok(_mapper.Map<ClienteResponse>(dbCliente));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
}