using Assinaturas.Application.Core.Behaviours.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Assinaturas.Application.Core;

public static class Configuration
{
    private static Assembly ApplicationAssemblyRef = typeof(Configuration).Assembly;

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(ApplicationAssemblyRef)
                .AddMediatR(config =>
                {
                    config.RegisterServicesFromAssembly(ApplicationAssemblyRef);
                    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                });

        return services;
    }
}