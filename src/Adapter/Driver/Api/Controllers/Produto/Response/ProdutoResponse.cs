using Domain.ValueObjects;

namespace Api.Controllers.Produto.Response;

public class ProdutoResponse
{
    public string Nome { get;  set; }
    public string Descricao { get;  set; }
    public CategoriaProdutoEnum Categoria { get;  set; }
    
    
    public double Preco { get;  set; }
    public string Imagem { get;  set; }
}