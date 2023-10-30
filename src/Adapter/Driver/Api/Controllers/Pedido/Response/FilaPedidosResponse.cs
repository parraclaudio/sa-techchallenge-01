using Domain.Entities;

namespace Api.Controllers.Pedido.Response;

public class FilaPedidosResponse
{
    /// <summary>
    /// Fila de controle de atendimento dos pedidos
    /// </summary>
    public IList<FilaPedidosData> FilaPedidos { get; set; }
}