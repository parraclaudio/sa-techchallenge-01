using Domain.ValueObjects;

namespace Infra.Entities;

public class OrdemPagamentoEntity :  BaseEntity
{
    public StatusPagamento StatusPagamento{ get;  set;}
    
    public DateTime DataCriacao{ get;  set;}
    
    public DateTime DataPagamento{ get;  set;}
    
    public double ValorTotal { get;  set; }
    
    public double ValorPago { get;  set; }
}