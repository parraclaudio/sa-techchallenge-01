using Domain.ValueObjects;

namespace Infra.Entities;

public class ProdutoEntity : BaseEntity
{
    public string Nome { get;  set; }
    public string Descricao { get;  set; }
    public CategoriaProdutoEnum Categoria { get;  set; }
    public double Preco { get;  set; }
    public string Imagem { get;  set; }
}