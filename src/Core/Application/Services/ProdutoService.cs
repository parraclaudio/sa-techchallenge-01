using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public void RegisterProduto(Produto produto)
    {
        _produtoRepository.Insert(produto);
    }

    public void EditProduto(Produto produto)
    {
        _produtoRepository.Update(produto);
    }

    public void RemoveProduto(string nome)
    {
        _produtoRepository.Delete(nome);
    }

    public IEnumerable<Produto> RetrieveProdutosByCategoria(CategoriaProdutoEnum categoriaProdutoEnum)
    {
        return _produtoRepository.GetProdutoByCategoria(categoriaProdutoEnum);
    }

    public Produto BuscaProdutoPorNome(string nomeProduto)
    {
        return _produtoRepository.PesquisaProdutoPorNome(nomeProduto);
    }
}