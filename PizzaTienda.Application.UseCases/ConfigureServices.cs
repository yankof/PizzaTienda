
using PizzaTienda.Application.Interfaces.UsesCases;
using PizzaTienda.Application.UseCases.Componente;
using PizzaTienda.Application.UseCases.Promocion;
namespace PizzaTienda.Application.UseCases;
public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IComponentApplication, ComponenteApplication>();
        services.AddScoped<IPedidoApplication, PedidoApplication>();
        services.AddScoped<IProductoApplication, ProductoApplication>();
        services.AddScoped<IProductoComponenteApplication, ProductoComponenteApplication>();
        services.AddScoped<IPromocionApplication, PromocionApplication>();

        services.AddTransient<ComponenteDtoValidator>();
        services.AddTransient<PedidoDtoValidator>();
        services.AddTransient<ProductoComponenteDtoValidator>();
        services.AddTransient<ProductoDtoValidator>();



        return services;
    }
}
