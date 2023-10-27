using Domain.ValueObjects;

namespace Domain.Entities;

public class OrdemDePagamento
{
    public StatusPagamento StatusPagamento{ get; private set;}
    
    public DateTime DataCriacao{ get; private set;}
    
    public double ValorTotal { get; private set; }
    
    public double ValorPago { get; private set; }
    
    public DateTime DataPagamento{ get; private set;}

    public OrdemDePagamento(double valorTotal)
    {
        StatusPagamento = StatusPagamento.PendentePagamento;
        DataCriacao = DateTime.Now;
        ValorTotal = valorTotal;
    }
    
    public OrdemDePagamento(StatusPagamento statusPagamento, DateTime dataCriacao, DateTime dataPagamento,  double valorTotal ,  double valorPago )
    {
        StatusPagamento = statusPagamento;
        DataCriacao = dataCriacao;
        DataPagamento = dataPagamento;
        ValorTotal = valorTotal;
        ValorPago = valorPago;
    }

    public void SetStatusPagamento(StatusPagamento statusPagamento, double valorPago )
    {
        StatusPagamento = statusPagamento;
        DataPagamento = DateTime.Now;
        ValorPago = valorPago;
    }
}