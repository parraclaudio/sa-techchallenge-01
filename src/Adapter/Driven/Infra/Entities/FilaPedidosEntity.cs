namespace Infra.Entities;

public class FilaPedidosEntity : BaseEntity
{
    public string NumeroPedido { get;  set; }
    
    public int Prioridade { get;  set; }
    
    public DateTime ExpectativaFinalizacao { get;  set; }
}