using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IProdutoRepository
{
     void Insert(Produto produto);
    
     void Update(Produto produto);
     
     void Delete(string nome);
     
     IEnumerable<Produto> GetProdutoByCategoria(CategoriaProdutoEnum categoriaProdutoEnum);
     
     Produto PesquisaProdutoPorNome(string nomeProduto);
}