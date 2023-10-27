using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Pedido;


[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }
    
    [HttpGet()]
    public IActionResult BuscarTodos()
    {
        try
        {
            var dbFilaPedidos = _pedidoService.BuscarTodosNaFila();
            
            if (dbFilaPedidos is not null)
            {
                //var clientResponse = new ClienteResponse(dbCliente);
                return Ok(dbFilaPedidos);
            }
            
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}