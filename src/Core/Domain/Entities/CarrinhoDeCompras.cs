namespace Domain.Entities;

public class CarrinhoDeCompras
{
    public double SomaDoPreco => Produtos.Sum(p => p.Preco);
    
    public int QuantidadeItens => Produtos.Count;
    
    public List<Produto> Produtos { get; private set; }
}