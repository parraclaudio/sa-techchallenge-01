using Api.Controllers.CarrinhoDeCompras.Request;
using Api.Controllers.CarrinhoDeCompras.Response;
using AutoMapper;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CarrinhoDeCompras;

/// <summary>
/// O carrinho de compras é onde os clientes podem navegar e salvar itens que estão considerando comprar. 
/// </summary>
[ApiController]
[Route("carrinhodecompras")]
[Produces("application/json")]
public class CarrinhoDeComprasController : ControllerBase
{
    private readonly ICarrinhoDeComprasService _carrinhoDeComprasService;
    private readonly IMapper _mapper;

    public CarrinhoDeComprasController(ICarrinhoDeComprasService carrinhoDeCompras, IMapper mapper)
    {
        _carrinhoDeComprasService = carrinhoDeCompras;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Adicionar produto
    /// </summary>
    /// <returns>Retorna o carrinho de compras</returns>
    /// <response code="200">Retorna o estado atual do carrinho de compras.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPost]
    [ProducesResponseType(typeof(CarrinhoDeComprasResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    public IActionResult AdicionarProduto(CarrinhoDeComprasRequest request)
    {
        try
        {
            var carrinhoDeCompras = _carrinhoDeComprasService.AdicionarProduto(request.NomeProduto, request.CPF);
            
            return Ok(_mapper.Map<CarrinhoDeComprasResponse>(carrinhoDeCompras));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
      
    /// <summary>
    /// Executar checkout
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o pedido criado</returns>
    /// <response code="200">Retorna o pedido criado.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPost]
    [ProducesResponseType(typeof(CheckoutResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [HttpPost]
    [Route("checkout")]
    public IActionResult Checkout(CheckoutRequest request)
    {
        try
        {
            var carrinhoDeCompras =  _carrinhoDeComprasService.ExecutarCheckout(request.idCarrinhoDeCompras);

            return Ok( _mapper.Map<CheckoutResponse>(carrinhoDeCompras));
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
    [ProducesResponseType(typeof(CheckoutResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult BuscaCarinhoDeComprasEmAbertoPorCPF(string cpf)
    {
        try
        {
            var carrinhoDeCompras =   _carrinhoDeComprasService.BuscarCarrinhoDeComprasPorCpf(cpf);
            
            return carrinhoDeCompras is null 
                ? NoContent() 
                : Ok( _mapper.Map<CarrinhoDeComprasResponse>(carrinhoDeCompras));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
}