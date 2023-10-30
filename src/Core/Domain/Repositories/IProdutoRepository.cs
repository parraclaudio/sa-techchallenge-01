using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IProdutoRepository
{
     void Inserir(Produto produto);
    
     void Atualizar(Produto produto);
     
     void Deletar(string nome);
     
     IEnumerable<Produto> PesquisarProdutosPorCategoria(CategoriaProdutoEnum categoriaProdutoEnum);
     
     Produto PesquisaProdutoPorNome(string nomeProduto);
}