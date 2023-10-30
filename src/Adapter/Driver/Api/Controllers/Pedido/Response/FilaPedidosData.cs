namespace Api.Controllers.Pedido.Response;

public class FilaPedidosData
{
    /// <summary>
    /// Identificação do pedido 
    /// </summary>
    public string NumeroPedido { get; set; }
    
    /// <summary>
    ///Prioridade de atendimento do pedido
    /// </summary>
    public int Prioridade { get; set; }
    
    /// <summary>
    /// Data esperado para finalização do pedido 
    /// </summary>
    public DateTime ExpectativaFinalizacao { get; set; }

    
    /// <summary>
    /// Tempo de aguardo para finalização do pedido 
    /// </summary>
    public TimeSpan TempoEspera { get; set; }
    
}