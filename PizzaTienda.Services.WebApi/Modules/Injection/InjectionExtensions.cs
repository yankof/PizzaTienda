namespace PizzaTienda.Services.WebApi.Modules.Injection;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjection (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(configuration);
        

        return services;
    }
}
