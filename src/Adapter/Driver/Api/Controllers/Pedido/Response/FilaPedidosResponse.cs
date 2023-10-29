using Domain.Entities;

namespace Api.Controllers.Pedido.Response;

public class FilaPedidosResponse
{
    public IList<FilaPedidosData> FilaPedidos { get; set; }
}