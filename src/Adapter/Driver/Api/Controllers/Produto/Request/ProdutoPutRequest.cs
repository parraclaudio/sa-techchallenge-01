using System.ComponentModel;
using Domain.ValueObjects;

namespace Api.Controllers.Produto.Request;

public class ProdutoPutRequest
{
    [DefaultValue("X-Egg")]
    public string Nome { get;  set; }
    [DefaultValue("Essa receita de hambúrguer com queijo, salada e ovo não deixa ninguém ficar com fome")]
    public string Descricao { get;  set; }
    [DefaultValue(CategoriaProdutoEnum.Lanche)]
    public CategoriaProdutoEnum Categoria { get;  set; }
    
    [DefaultValue(39.90)]
    public double Preco { get;  set; }
    [DefaultValue("x-egg.png")]
    public string Imagem { get;  set; }
}