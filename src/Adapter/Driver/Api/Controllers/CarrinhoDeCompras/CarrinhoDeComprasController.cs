using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CarrinhoDeCompras;


[ApiController]
[Route("[controller]")]
public class CarrinhoDeComprasController : ControllerBase
{
    private readonly ICarrinhoDeComprasService _carrinhoDeComprasService;
    private readonly IClienteService _clienteService;

    public CarrinhoDeComprasController(ICarrinhoDeComprasService carrinhoDeCompras, IClienteService clienteService)
    {
        _carrinhoDeComprasService = carrinhoDeCompras;
        _clienteService = clienteService;
    }
    
    [HttpPost]
    public IActionResult AdicionarProduto(string NomeProduto, string? cpf)
    {
        try
        {
            var carrinho = _carrinhoDeComprasService.AdicionarProduto(NomeProduto, cpf);

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