namespace Api.Controllers.Produto.Response;

public class ProdutosResponse
{
    public ProdutosResponse(IEnumerable<ProdutoResponse> produtos)
    {
        Produtos = produtos;
    }
    public IEnumerable<ProdutoResponse> Produtos { get; private set; }
}