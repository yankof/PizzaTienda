namespace PizzaTienda.Application.UseCases.Common.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<PizzaTienda.Domain.Entities.Pedido, PedidoDto>().ReverseMap();
        CreateMap<PizzaTienda.Domain.Entities.Componentes, ComponenteDto>().ReverseMap();
        CreateMap<PizzaTienda.Domain.Entities.Producto, ProductoDto>().ReverseMap();
        CreateMap<PizzaTienda.Domain.Entities.ProductoComponente, ProductoComponenteDto>().ReverseMap();
        CreateMap<PizzaTienda.Domain.Entities.Promocion, PromocionDto>().ReverseMap();
    }

}
