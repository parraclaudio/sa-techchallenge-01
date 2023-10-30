using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;

public interface IProdutoService
{
    void CadastrarProduto(Produto produto);
    
    void EditarProduto(Produto produto);
    
    void RemoverProduto(string nome);
    
    IEnumerable<Produto>  BuscarProdutosPorCategoria(CategoriaProdutoEnum categoriaProdutoEnum);
    
    Produto  BuscarProdutoPorNome(string nomeProduto);
}   