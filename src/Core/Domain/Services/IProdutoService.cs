using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;

public interface IProdutoService
{
    void RegisterProduto(Produto produto);
    
    void EditProduto(Produto produto);
    
    void RemoveProduto(string nome);
    
    IEnumerable<Produto>  RetrieveProdutosByCategoria(CategoriaProdutoEnum categoriaProdutoEnum);
}   