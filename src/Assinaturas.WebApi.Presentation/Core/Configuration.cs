using Assinaturas.Application.Core;
using Assinaturas.Infrastructure.IoC;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Assinaturas.WebApi.Presentation.Core.GlobalErrorHandler;

namespace Assinaturas.WebApi.Presentation.Core;

public static class Configuration
{
    public static WebApplication ConfigureAndBuild(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddPresentation();
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddInfrastructureServices(builder.Configuration);

        var app = builder.Build();

        app.MapCarter();

        app.UseExceptionHandler(HandleError);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        return app;
    }

    private static IServiceCollection AddPresentation(this IServiceCollection services)
        => services
            .AddCarter()
            .AddAuthorization()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
}