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

    public void CadastrarProduto(Produto produto)
    {
        _produtoRepository.Inserir(produto);
    }

    public void EditarProduto(Produto produto)
    {
        _produtoRepository.Atualizar(produto);
    }

    public void RemoverProduto(string nome)
    {
        _produtoRepository.Deletar(nome);
    }

    public IEnumerable<Produto> BuscarProdutosPorCategoria(CategoriaProdutoEnum categoriaProdutoEnum)
    {
        return _produtoRepository.PesquisarProdutosPorCategoria(categoriaProdutoEnum);
    }

    public Produto BuscarProdutoPorNome(string nomeProduto)
    {
        return _produtoRepository.PesquisaProdutoPorNome(nomeProduto);
    }
}