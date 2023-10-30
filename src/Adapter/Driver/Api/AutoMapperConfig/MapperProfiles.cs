using Api.Controllers.CarrinhoDeCompras.Response;
using Api.Controllers.Cliente.Response;
using Api.Controllers.Pedido.Response;
using Api.Controllers.Produto.Response;
using AutoMapper;
using Domain.Entities;

namespace Api.AutoMapperConfig;

/// <summary>
/// 
/// </summary>
public class MapperProfiles : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public MapperProfiles()
    {
       CreateMap<CarrinhoDeCompras, CarrinhoDeComprasResponse>();
       CreateMap<CarrinhoDeCompras, CheckoutResponse>();
       CreateMap<Cliente, ClienteResponse>();
       CreateMap<Produto, ProdutoResponse>();
       //  CreateMap<IList<FilaPedidos>, IList<FilaPedidosData>>();
    }
}