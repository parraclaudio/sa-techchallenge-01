using Domain.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Produto;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }
    
    [HttpPost]
    public IActionResult Post(ProdutoRequest produtoRequest)
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
            return BadRequest(e.Message);
        }
    }
    
       
    [HttpPatch]
    public IActionResult Patch(ProdutoRequest produtoRequest)
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
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    public IActionResult Delete(string name)
    {
        try
        {
            _produtoService.RemoveProduto(name);

            return Ok("Produto removido com sucesso!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public IActionResult GetByCategoria(CategoriaProdutoEnum categoria)
    {
        try
        {
            return Ok( _produtoService.RetrieveProdutosByCategoria(categoria));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}