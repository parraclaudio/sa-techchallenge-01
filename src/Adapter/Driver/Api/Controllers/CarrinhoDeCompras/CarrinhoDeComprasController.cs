using Api.Controllers.CarrinhoDeCompras.Request;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CarrinhoDeCompras;


[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CarrinhoDeComprasController : ControllerBase
{
    private readonly ICarrinhoDeComprasService _carrinhoDeComprasService;

    public CarrinhoDeComprasController(ICarrinhoDeComprasService carrinhoDeCompras)
    {
        _carrinhoDeComprasService = carrinhoDeCompras;
    }
    
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o carrinho de compras</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /CarrinhoDeCompras
    ///     {
    ///        "nomeProduto": "X-Bacon",
    ///        "cpf": "58669754088"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Retorna o estado atual do carrinho de compras.</response>
    /// <response code="400">Retornado quando um fluxo de exceção ocorreu.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AdicionarProduto(CarrinhoDeComprasRequest request)
    {
        try
        {
            var carrinho = _carrinhoDeComprasService.AdicionarProduto(request.NomeProduto, request.CPF);

            return Ok(carrinho);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("checkout")]
    public IActionResult Checkout(string idCarrinhoDeCompras)
    {
        try
        {
            var carrinho =  _carrinhoDeComprasService.ExecutarCheckout(idCarrinhoDeCompras);

            return Ok($"Checkout Realizado com Sucesso , Pedido Gerado: {carrinho.NumeroPedido}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{cpf}")]
    public IActionResult Get(string cpf)
    {
        try
        {
            var dbCarrinho =   _carrinhoDeComprasService.BuscarCarrinhoDeComprasPorCpf(cpf);
            
            if (dbCarrinho is not null)
            {
                //var clientResponse = new ClienteResponse(dbCliente);
                return Ok(dbCarrinho);
            }
            
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}