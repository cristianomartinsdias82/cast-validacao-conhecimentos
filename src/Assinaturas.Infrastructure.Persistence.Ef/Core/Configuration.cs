using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assinaturas.Infrastructure.Persistence.Ef.Core;

public static class Configuration
{
    public static IServiceCollection AddEfBasedPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        

        return services;
    }
}