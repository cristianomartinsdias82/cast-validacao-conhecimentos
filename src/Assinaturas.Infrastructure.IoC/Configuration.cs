using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Assinaturas.Infrastructure.Integrations.ViaCep.Core;
using Assinaturas.Infrastructure.Persistence.Ef.Core;

namespace Assinaturas.Infrastructure.IoC;

public static class Configuration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddViaCepIntegrationClient(configuration)
                .AddEfBasedPersistence(configuration);

        return services;
    }
}