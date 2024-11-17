﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PizzaTienda.Services.WebApi.Modules.Swagger;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    readonly IApiVersionDescriptionProvider provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
    /// </summary>
    /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

    /// <inheritdoc />
    public void Configure(SwaggerGenOptions options)
    {
        // add a swagger document for each discovered API version
        // note: you might choose to skip or document deprecated API versions differently
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Version = description.ApiVersion.ToString(),
            Title = "Tienda de Pizzas",
            Description = "Ejercicio descuentos y ofertas en la tienda de pizzas",
            TermsOfService = new Uri("https://MicroPizzas/terms"),
            Contact = new OpenApiContact
            {
                Name = "Freddy Ortiz",
                Email = "yankof@hotmail.com",
                Url = new Uri("https://MicroPizzas/contact")
            },
            License = new OpenApiLicense
            {
                Name = "Use under LICX",
                Url = new Uri("https://MicroPizzas.com/licence")
            }
        };

        if (description.IsDeprecated)
        {
            info.Description += "Esta versión de la API ha quedado obsoleta.";
        }

        return info;
    }
}
