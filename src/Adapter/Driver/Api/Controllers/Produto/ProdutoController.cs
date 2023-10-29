using Api.Controllers.Pedido.Response;
using Api.Controllers.Produto.Request;
using Api.Controllers.Produto.Response;
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

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }
    
    /// <summary>
    /// CadastrarNovoProduto
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o pedido criado</returns>
    /// <response code="200">Retorna o pedido criado.</response>
    /// /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(FilaPedidosResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CadastrarNovoProduto(ProdutoRequest produtoRequest)
    {
        try
        {
            var produto = new Domain.Entities.Produto(produtoRequest.Nome, produtoRequest.Descricao,
                produtoRequest.Categoria, produtoRequest.Preco, produtoRequest.Imagem);
            
            _produtoService.RegisterProduto(produto);

            return Ok("Produto cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    /// <summary>
    /// AtualizarProduto
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o pedido criado</returns>
    /// <response code="200">Retorna o pedido criado.</response>
    /// /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpPatch("atualizar")]
    [ProducesResponseType(typeof(FilaPedidosResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizarProduto(ProdutoRequest produtoRequest)
    {
        try
        {
            var produto = new Domain.Entities.Produto(produtoRequest.Nome, produtoRequest.Descricao,
                produtoRequest.Categoria, produtoRequest.Preco, produtoRequest.Imagem);
            
            _produtoService.EditProduto(produto);

            return Ok("Produto alterado com sucesso!");
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    
    /// <summary>
    /// RemoverProduto
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o pedido criado</returns>
    /// <response code="200">Retorna o pedido criado.</response>
    /// /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpDelete("remover")]
    [ProducesResponseType(typeof(FilaPedidosResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult RemoverProduto(string name)
    {
        try
        {
            _produtoService.RemoveProduto(name);

            return Ok("Produto removido com sucesso!");
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
    
    /// <summary>
    /// BuscarPorCategoria
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Retorna o pedido criado</returns>
    /// <response code="200">Retorna o pedido criado.</response>
    /// /// <response code="204">Retorna qunando não obteve dados na consulta.</response>
    /// <response code="400">Retorna Mensagem de Erro, gerado quando um fluxo de exceção ocorreu.</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(FilaPedidosResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Data.ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult BuscarPorCategoria(CategoriaProdutoEnum categoria)
    {
        try
        {
            var dbProdutos = _produtoService.RetrieveProdutosByCategoria(categoria);

            if (!dbProdutos.Any())
                return NotFound();
            
            return Ok(new ProdutoResponse(dbProdutos));
        }
        catch (Exception e)
        {
            return BadRequest(new Data.ErrorResponse(e.Message));
        }
    }
}