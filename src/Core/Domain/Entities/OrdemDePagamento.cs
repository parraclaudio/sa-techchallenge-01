using Domain.ValueObjects;

namespace Domain.Entities;

public class OrdemDePagamento
{
    public Guid IdOrdemDePagamento { get; private set;}
    public Guid IdCarrinhoDeCompras { get; private set;} 
    
    public StatusPagamento StatusPagamento{ get; private set;}

    public OrdemDePagamento(Guid idCarrinhoDeCompras)
    {
        IdCarrinhoDeCompras = idCarrinhoDeCompras;
        IdOrdemDePagamento = Guid.NewGuid();
        StatusPagamento = StatusPagamento.PendentePagamento;
    }

    public void SetStatusPagamento(StatusPagamento statusPagamento)
    {
        StatusPagamento = statusPagamento;
    }
}