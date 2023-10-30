using Api.Controllers.Pedido.Response;
using Api.Controllers.Produto.Request;
using Api.Controllers.Produto.Response;
using AutoMapper;
using Domain.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Produto;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("produto")]
[Produces("application/json")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    private readonly IMapper _mapper;

    public ProdutoController(IProdutoService produtoService, IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Cadastrar Produto
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o produto criado</returns>
    /// <response code="200">Retorna o produto criado.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(ProdutoResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CadastrarProduto(ProdutoRequest produtoRequest)
    {
        try
        {
            var produto = new Domain.Entities.Produto(produtoRequest.Nome, produtoRequest.Descricao,
                produtoRequest.Categoria, produtoRequest.Preco, produtoRequest.Imagem);
            
            _produtoService.CadastrarProduto(produto);

            return Ok(_mapper.Map<ProdutoResponse>(produto));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    /// <summary>
    /// Editar produto
    /// </summary>
    /// <returns>Retorna o produto editado</returns>
    /// <response code="200">Retorna o produto editado.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPut("editar")]
    [ProducesResponseType(typeof(ProdutoResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    public IActionResult AtualizarProduto(ProdutoPutRequest produtoRequest)
    {
        try
        {
            var produto = new Domain.Entities.Produto(produtoRequest.Nome, produtoRequest.Descricao,
                produtoRequest.Categoria, produtoRequest.Preco, produtoRequest.Imagem);
            
            _produtoService.EditarProduto(produto);

            return Ok(_mapper.Map<ProdutoResponse>(produto));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    
    /// <summary>
    /// Remover Produto
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Remove um produto cadastrado</returns>
    /// <response code="200">Retorna quando há sucesso na operaçõa</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpDelete("remover")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult RemoverProduto(string name = "X-Egg")
    {
        try
        {
            _produtoService.RemoverProduto(name);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    /// <summary>
    /// Buscar produto por categoria
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna os produtos pesquisados</returns>
    /// <response code="200">Retorna o resultado da pesquisa</response>
    /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(ProdutosResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult BuscarPorCategoria(CategoriaProdutoEnum categoria = CategoriaProdutoEnum.Lanche)
    {
        try
        {
            var dbProdutos = _produtoService.BuscarProdutosPorCategoria(categoria);

            if (!dbProdutos.Any())
                return NoContent();

            var map = _mapper.Map<IEnumerable<Domain.Entities.Produto>, IEnumerable<ProdutoResponse>>(dbProdutos);
            return Ok(new ProdutosResponse(map));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
}