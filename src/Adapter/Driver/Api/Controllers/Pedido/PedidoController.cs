﻿using Api.Controllers.Pedido.Response;
using AutoMapper;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Pedido;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("pedido")]
[Produces("application/json")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    private readonly IMapper _mapper;

    public PedidoController(IPedidoService pedidoService, IMapper mapper)
    {
        _pedidoService = pedidoService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Acompanhar pedidos
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o pedido criado</returns>
    /// <response code="200">Retorna o pedido criado.</response>
    /// /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpGet("listartodos")]
    [ProducesResponseType(typeof(FilaPedidosResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ListarTodos()
    {
        try
        {
            var dbFilaPedidos = _pedidoService.BuscarTodosNaFila();
            
            if (dbFilaPedidos.Count > 0)
            {
                var response = _mapper.Map<IList<FilaPedidosData>>(dbFilaPedidos);
                return Ok(new FilaPedidosResponse(){ FilaPedidos = response});
            }
            
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
}