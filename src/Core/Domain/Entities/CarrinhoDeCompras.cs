using Domain.ValueObjects;

namespace Domain.Entities;

public class CarrinhoDeCompras
{
    public CarrinhoDeCompras(string idAtendimento)
    {
        IdAtendimento = idAtendimento;
        IdCarrinhoDeCompras = Guid.NewGuid().ToString();
        Status = StatusCarrinhoDeCompras.EmAberto;
        Produtos = new List<Produto>();
        OrdemDePagamento = new OrdemDePagamento(SomaDoPreco);
    }
    
    public CarrinhoDeCompras(string idAtendimento, string cpf)
    {
        IdAtendimento = idAtendimento;
        IdCarrinhoDeCompras = Guid.NewGuid().ToString();
        CPF = cpf;
        Status = StatusCarrinhoDeCompras.EmAberto;
        Produtos = new List<Produto>();
        OrdemDePagamento = new OrdemDePagamento(SomaDoPreco);
    }
    
    public CarrinhoDeCompras(string idAtendimento, string idCarrinhoDeCompras, List<Produto> produtos, OrdemDePagamento? ordemDePagamento,string? cpf = null)
    {
        IdAtendimento = idAtendimento;
        IdCarrinhoDeCompras = idCarrinhoDeCompras;
        CPF = cpf;
        Status = StatusCarrinhoDeCompras.EmAberto;
        Produtos = produtos;
        OrdemDePagamento = ordemDePagamento;
    }

    public string IdAtendimento { get; private set; }
    public string IdCarrinhoDeCompras { get; private set; }
    
    public bool ClienteIdentificado => (CPF is not null);
    
    public string? CPF { get; private set;}

    public StatusCarrinhoDeCompras Status { get; private set; }
    
    public OrdemDePagamento OrdemDePagamento { get; private set;}
    
    public List<Produto> Produtos { get; private set; }
    
    public void SetStatus(StatusCarrinhoDeCompras statusCarrinhoDeCompras)
    {
        Status = statusCarrinhoDeCompras;
    }

    public string NumeroPedido { get; private set; }
    
    public void ExecuteCheckout()
    {
        OrdemDePagamento = new OrdemDePagamento(SomaDoPreco);
        OrdemDePagamento.SetStatusPagamento(StatusPagamento.PagamentoEfetuado, SomaDoPreco);
        Status = StatusCarrinhoDeCompras.Finalizado;
    }

    public void SetNumeroPedido(string numeroPedido)
    {
        NumeroPedido = numeroPedido;
    }

    public double SomaDoPreco => Produtos.Sum(p => p.Preco);
    
    public int QuantidadeItens => Produtos.Count;

}