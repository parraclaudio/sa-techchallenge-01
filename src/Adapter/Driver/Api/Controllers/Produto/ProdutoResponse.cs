using Domain.ValueObjects;

namespace Api.Controllers.Produto;

public class ProdutoResponse
{
    public ProdutoResponse(IEnumerable<Domain.Entities.Produto> produtos)
    {
        Produtos = produtos;
    }
    public IEnumerable<Domain.Entities.Produto> Produtos { get; private set; }
    
}