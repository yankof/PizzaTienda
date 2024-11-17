using System.Text.Json.Serialization;

namespace PizzaTienda.Services.WebApi.Modules.Features;

public static class FeatureExtensions
{
    public static IServiceCollection AddFeatures(this IServiceCollection services, IConfiguration configuration)
    {
        string myPolicy = "policyApiEcommerce";

        services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                                    .AllowAnyHeader()
                                                                                    .AllowAnyMethod()
                                                                                    .AllowAnyOrigin()));
        services.AddMvc();
        services.AddControllers().AddJsonOptions(opts =>
        {
            var enumConverter = new JsonStringEnumConverter();
            opts.JsonSerializerOptions.Converters.Add(enumConverter);
        });

        return services;
    }
}
