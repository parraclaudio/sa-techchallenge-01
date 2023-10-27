using Domain.ValueObjects;

namespace Domain.Entities;

public class CarrinhoDeCompras
{
    public CarrinhoDeCompras()
    {
        IdCarrinhoDeCompras = Guid.NewGuid();
        Status = StatusCarrinhoDeCompras.EmAberto;
        Produtos = new List<Produto>();
    }
    
    public StatusCarrinhoDeCompras Status { get; private set; }
    
    public Guid IdCarrinhoDeCompras { get; private set;} 
    
    public List<Produto> Produtos { get; private set; }
    
    public void SetStatus(StatusCarrinhoDeCompras statusCarrinhoDeCompras)
    {
        Status = statusCarrinhoDeCompras;
    }

    public double SomaDoPreco => Produtos.Sum(p => p.Preco);
    
    public int QuantidadeItens => Produtos.Count;

}