namespace PizzaTienda.Persistence;
public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices (this IServiceCollection services, IConfiguration configuration )
    {

        var connectionString = configuration.GetConnectionString("PizzaConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
                                options.UseSqlServer(configuration.GetConnectionString("PizzaConnection")));

        services.AddScoped<IComponentes, ComponentesRepository>();
        services.AddScoped<IPedidos, PedidoRepository>();
        services.AddScoped<IProducto, ProductoRepository>();
        services.AddScoped<IProductoComponente, ProductoComponenteRepository>();
        services.AddScoped<IPromocion,  PromocionRepository>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;

    }
}
