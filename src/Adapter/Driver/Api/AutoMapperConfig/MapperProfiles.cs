using Api.Controllers.CarrinhoDeCompras.Response;
using AutoMapper;
using Domain.Entities;

namespace Api.AutoMapperConfig;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
       CreateMap<CarrinhoDeCompras, CarrinhoDeComprasResponse>();
       CreateMap<CarrinhoDeCompras, CheckoutResponse>();
    }
}