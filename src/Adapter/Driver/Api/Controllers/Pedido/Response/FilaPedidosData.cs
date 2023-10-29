namespace Api.Controllers.Pedido.Response;

public class FilaPedidosData
{
    public string NumeroPedido { get; set; }

    public int Prioridade { get; set; }
    public DateTime ExpectativaFinalizacao { get; set; }

    public TimeSpan TempoEspera { get; set; }
    
}